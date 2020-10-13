using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.DTO.Requests
{
    public class ChangePasswordRequest
    {
        public string Login { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
