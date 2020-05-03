using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Texter.Domain.Models;
using Texter.Domain.RepositoryInterface.DeviceRepository;
using Texter.Domain.Services;

namespace Texter.Services.DeviceService
{
    public class DeviceService: IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;
        public DeviceService(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }
        public async Task<Device> GetByIdAsync(long id)
        {
            return await _deviceRepository.GetByIdAsync(id);
        }

        public async Task<Device> GetByAddrAsync(string address)
        {
            return await _deviceRepository.GetByAddrAsync(address);
        }
    }
}
