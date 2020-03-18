using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public async Task<IEnumerable<MessageDTO>> ListAsync()
        {
            return await _messageRepository.ListAsync();

        }
    }
}
