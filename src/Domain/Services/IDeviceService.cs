using System.Collections.Generic;
using System.Threading.Tasks;
using Texter.Domain.Models;

namespace Texter.Domain.Services
{
    public interface IDeviceService
    {
        public Task<IEnumerable<Device>> ListAsync();
        public Task<Device> GetByIdAsync(long id);

        public Task<Device> GetDeviceByAddrAsync(string addr);
    }
}
