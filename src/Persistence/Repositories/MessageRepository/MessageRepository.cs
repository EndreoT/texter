
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Texter.Persistence.Repositories;
using Texter.Persistence.Context;
using Texter.Domain.Models;
using Texter.Domain.RepositoryInterface.MessageRepository;
using Texter.DataTransferObject;

namespace Texter.Persistence.Repositories.MessageRepository
{
    public class MessageRepository: BaseRepository, IMessageRepository
    {
        public MessageRepository(AppDbContext context) : base(context) { }

        public async Task<IEnumerable<MessageDTO>> ListAsync()
        {
            return await _context.Messages.Select(message => ToMessageDTO(message)).ToListAsync();
        }   

        private static MessageDTO ToMessageDTO(Message message)
        {
            return new MessageDTO
            {
                Id = message.Id,
                SourceAddr = message.SourceAddr,
                DestAddr = message.DestAddr,
                Content = message.Content,
            };
        }
    }
}
