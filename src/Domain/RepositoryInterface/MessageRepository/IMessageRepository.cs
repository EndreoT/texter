using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Texter.Domain.Models;


namespace Texter.Domain.RepositoryInterface.MessageRepository
{
    public interface IMessageRepository
    {
        public Task<IEnumerable<Message>> ListAsync();

        public Task<Message> GetByIdAsync(long id);

        public Task CreateMessageAsync(Message message);
    }
}
