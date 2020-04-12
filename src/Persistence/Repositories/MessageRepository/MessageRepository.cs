
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

        public async Task<IEnumerable<Message>> ListAsync()
        {
            return await _context.Messages.ToListAsync();
        }

        public async Task<Message> GetByIdAsync(long id)
        {
            try
            {
                return await _context.Messages
                   .Where(message => message.Id == id)
                   .SingleAsync();
            } catch (InvalidOperationException)
            {
                return null;
            }
        }

        public async Task CreateMessageAsync(Message message)
        {
            await _context.Messages.AddAsync(message);
        }

        public void UpdateMessageAsync(Message message)
        {
            _context.Messages.Update(message);
        }

        public void DeleteMessageAsync(Message message)
        {
            _context.Messages.Remove(message);
        }
    }
}
