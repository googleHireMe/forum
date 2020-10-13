using Forum.DTO.Requests;
using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.Database.Models
{
    public class Topic
    {
        [Key]
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public Guid AuthorId { get; set; }
        public User Author { get; set; }

        public void UpdateFieldsFromRequest(TopicRequest request)
        {
            Id = request.Id;
            Content = request.Content;
            CreationDate = request.CreationDate;
        }
    }
}
