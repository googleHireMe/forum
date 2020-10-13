using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace forum.DTO.Responses
{
    public class TopicResponse
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastUpdateDate { get; set; }
    }
}
