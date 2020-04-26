
using AutoMapper;
using Texter.Domain.Models;
using Texter.DataTransferObject;

namespace TexterMapping
{
    public class ResourceToMessageModelProfile : Profile
    {
        public ResourceToMessageModelProfile()
        {
            CreateMap<SaveMessageDTO, Message>();
        }
    }
}