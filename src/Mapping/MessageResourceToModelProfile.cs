
using AutoMapper;
using Texter.Domain.Models;
using Texter.DataTransferObject;

namespace TexterMapping
{
    public class MessageModelToResourceProfile : Profile
    {
        public MessageModelToResourceProfile()
        {
            CreateMap<SaveMessageDTO, Message>();
        }
    }
}