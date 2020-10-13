using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Forum.Database.Contexts;
using Forum.Database.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Forum
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        private readonly string corsPolicyName = "cors";
        private readonly string forumConnectionString = "ForumConnection";
        private readonly string identityConnectionString = "IdentityConnection";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            ConfigureDatabase(services);
            ConfigureIdentity(services);
            ConfigureCors(services);
            ConfigureDependencies(services);
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers()
                .AddNewtonsoftJson(o =>
                {
                    o.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Serialize;
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseCors(corsPolicyName);
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void ConfigureDependencies(IServiceCollection services)
        {
            // services.AddTransient<IDatabaseInitializer, PrioritiesInitializer>();
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            services.AddDbContext<DatabaseContext>(options => 
                options.UseSqlServer(Configuration.GetConnectionString(forumConnectionString)));
        }

        private void ConfigureIdentity(IServiceCollection services)
        {
            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString(identityConnectionString)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromDays(10000);
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            });
        }

        private void ConfigureCors(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(corsPolicyName,
                    policy =>
                    {
                        policy.AllowCredentials()
                            .WithOrigins(
                            "http://localhost:4400",
                            "https://localhost:4400")
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
        }
    }
}
