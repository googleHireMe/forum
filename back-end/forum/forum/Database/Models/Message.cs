using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.Database.Models
{
    public class Message
    {
        [Key]
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }

        public Guid TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
