using AutoMapper;
using Texter.DataTransferObject;
using Texter.Domain.Models;

namespace TexterMapping
{
    public class MessageModelToResourceProfile : Profile
    {
        public MessageModelToResourceProfile()
        {
            CreateMap<Message, FromMessageDTO>();
        }
    }
}