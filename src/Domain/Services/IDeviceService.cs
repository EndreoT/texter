using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Texter.Domain.Models;

namespace Texter.Domain.Services
{
    public interface IDeviceService
    {
        public Task<Device> GetByIdAsync(long id);

        public Task<Device> GetByAddrAsync(string addr);
    }
}
