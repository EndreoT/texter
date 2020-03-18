using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Texter.Domain.Models;
using Texter.DataTransferObject;

namespace Texter.Domain.RepositoryInterface.MessageRepository
{
    public interface IMessageRepository
    {
        public Task<IEnumerable<MessageDTO>> ListAsync();
    }
}
