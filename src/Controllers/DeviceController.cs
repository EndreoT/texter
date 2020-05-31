using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Texter.Domain.Models;
using Texter.Domain.Services;


namespace Texter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IDeviceService _deviceService;

        public DeviceController(IDeviceService deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpGet]
        public async Task<IEnumerable<Device>> GetDevicesAsync()
        {
            return await _deviceService.ListAsync();
        }
    }
}
