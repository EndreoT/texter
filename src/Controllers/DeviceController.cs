using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Texter.Domain.Models;
using Texter.Persistence.Context;
using Texter.Domain.Services;
using Texter.Services.DeviceService;
using Texter.DataTransferObject;
using Texter.ExtensionMethods;
using Texter.Domain.Services.Communication;


namespace Texter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController: ControllerBase
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
