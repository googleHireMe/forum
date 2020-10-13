using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forum.Database.Contexts;
using Forum.Database.Models;
using Forum.DTO.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Controllers
{
    [Authorize]
    [Route("Api/[controller]")]
    public class AccountController : ControllerBase
    {
        private UserManager<ApplicationUser> userManager;
        private SignInManager<ApplicationUser> signInManager;
        private DatabaseContext forumContext;

        public AccountController(UserManager<ApplicationUser> userManager,
                                 SignInManager<ApplicationUser> signInManager,
                                 DatabaseContext forumContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.forumContext = forumContext;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest model)
        {
            var appUser = await userManager.FindByEmailAsync(model.Login);
            if (appUser != null)
            {
                await signInManager.SignOutAsync();
                var signInResult = await signInManager.PasswordSignInAsync(appUser, model.Password, true, false);
                if (signInResult.Succeeded)
                {
                    return Ok();
                }
            }
            return Unauthorized();
        }


        [AllowAnonymous]
        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterAccountRequest model)
        {
            var appUser = new ApplicationUser()
            {
                Email = model.Login,
                UserName = model.Login,
                SecurityStamp = Guid.NewGuid().ToString()
            };
            var result = await userManager.CreateAsync(appUser, model.Password);
            if (result.Succeeded)
            {
                var user = new User
                {
                    Login = model.Login,
                    Password = model.Password
                };
                forumContext.Add(user);
                forumContext.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [Authorize]
        [HttpPost]
        [Route("ChangePassword")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordRequest model)
        {
            var appUser = await userManager.GetUserAsync(User);
            var result = await userManager.ChangePasswordAsync(appUser, model.CurrentPassword, model.NewPassword);
            if (result.Succeeded)
            {
                var user = forumContext.Users.Single(u => u.Id.ToString() == appUser.Id);
                user.Password = model.NewPassword;
                forumContext.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
