using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Texter.Domain.Models;
using Texter.DataTransferObject;
using Texter.Domain.Services.Communication;

namespace Texter.Domain.Services
{
    public interface IMessageService
    {
        public Task<IEnumerable<FromMessageDTO>> ListAsync();

        public Task<FromMessageDTO> GetById(long id);

        public Task<SaveMessageResponse> CreateMessageAsync(SaveMessageDTO message);
    }
}
