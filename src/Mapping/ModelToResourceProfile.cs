using AutoMapper;
using Texter.Domain.Models;
using Texter.DataTransferObject;

namespace Supermarket.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Message, MessageDTO>();
        }
    }
}