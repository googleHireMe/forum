using AutoMapper;
using forum.DTO.Responses;
using Forum.Database.Models;

namespace Forum.DTO.MapperProfiles
{
    public class MessageProfile : Profile
    {
        public MessageProfile()
        {
            CreateMap<Message, MessageResponse>().ReverseMap();
        }
    }
}
