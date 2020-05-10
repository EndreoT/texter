
//using AutoMapper;
//using Texter.Domain.Models;
//using Texter.DataTransferObject;

//namespace TexterMapping
//{
//    public class CustomResolver : IValueResolver<SaveMessageDTO, Message, long>
//    {
//        public long Resolve(SaveMessageDTO source, Message destination, long member, ResolutionContext context)
//        {
//            return 5L;
//        }
//    }

//    public class ResourceToMessageModelProfile : Profile
//    {
//        public ResourceToMessageModelProfile()
//        {
//            CreateMap<SaveMessageDTO, Message>()
//                .ForMember(dest => dest.MessageId, opt => opt.MapFrom<CustomResolver>());

//        }
//    }
//}