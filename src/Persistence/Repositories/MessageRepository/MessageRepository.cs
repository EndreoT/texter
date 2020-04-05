
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

        public async Task<Message> GetById(long id)
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

        //public static int CreateMessage(MessageDTO message)
        //{

        //}


    }
}
