using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Texter.Domain.ServiceInterface;
using Texter.Domain.Models;
using Texter.Persistence.Repositories.MessageRepository;
using Texter.DataTransferObject;
using Texter.Domain.RepositoryInterface.MessageRepository;

namespace Texter.Services.MessageServices
{
    public class MessageService: IMessageService
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public MessageService(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MessageDTO>> ListAsync()
        {
            IEnumerable<Message> messages = await _messageRepository.ListAsync();
            IEnumerable<MessageDTO> resources = _mapper.Map<IEnumerable<Message>, IEnumerable<MessageDTO>>(messages);
            return resources;
        }

        public async Task<MessageDTO> GetById(long id)
        {
            Message message = await _messageRepository.GetById(id);
            MessageDTO resource = _mapper.Map<Message, MessageDTO>(message);
            return resource;
        }
    }
}
