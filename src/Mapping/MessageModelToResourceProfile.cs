using AutoMapper;
using Texter.Domain.Models;
using Texter.DataTransferObject;

namespace Supermarket.API.Mapping
{
    public class MessageModelToResourceProfile : Profile
    {
        public MessageModelToResourceProfile()
        {
            CreateMap<Message, FromMessageDTO>();
        }
    }
}