using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Texter.Domain.Models;
using Texter.DataTransferObject;

namespace Texter.Domain.ServiceInterface
{
    public interface IMessageService
    {
        public Task<IEnumerable<MessageDTO>> ListAsync();
    }
}
