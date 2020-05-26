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
        public Task<IEnumerable<FromMessageDTO>> ListPopultateDeviceAsync();

        public Task<FromMessageDTO> GetById(long id);

        public Task<MessageResponse> CreateMessageAsync(SaveMessageDTO message);

        public Task<MessageResponse> UpdateMessageAsync(long id, SaveMessageDTO messageDTO);

        public Task<MessageResponse> DeleteMessageAsync(long id);

        public Task<IEnumerable<FromMessageDTO>> GetMessagesForDestDeviceAync(string deviceAddr);

        public IEnumerable<FromMessageDTO> GetMessagesForDestDeviceFromMessageMem(string deviceAddr);
    }
}
