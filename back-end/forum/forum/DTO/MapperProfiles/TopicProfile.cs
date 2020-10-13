using AutoMapper;
using forum.DTO.Responses;
using Forum.Database.Models;

namespace Forum.DTO.MapperProfiles
{
    public class TopicProfile : Profile
    {
        public TopicProfile()
        {
            CreateMap<Topic, TopicResponse>().ReverseMap();
        }
    }
}
