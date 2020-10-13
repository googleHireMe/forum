using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Forum.Database.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public ICollection<Topic> Topics { get; set; }
    }
}
