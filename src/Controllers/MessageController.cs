using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using Texter.DataTransferObject;
using Texter.Domain.Services;
using Texter.Domain.Services.Communication;
using Texter.ExtensionMethods;

namespace Texter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<FromMessageDTO>> GetMessages()
        {
            return await _messageService.ListPopultateDeviceAsync();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FromMessageDTO>> GetById(long id)
        {
            FromMessageDTO messageDTO = await _messageService.GetById(id);

            if (messageDTO == null)
            {
                return NotFound();
            }

            return messageDTO;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<FromMessageDTO>> CreateMessage([FromBody] SaveMessageDTO saveMessageDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            MessageResponse result = await _messageService.CreateMessageAsync(saveMessageDTO);

            if (!result.Success)
                return BadRequest(result.Message);

            return CreatedAtAction("test", result.MessageDTO);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<FromMessageDTO>> UpdateMessage(long id, SaveMessageDTO saveMessage)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            MessageResponse result = await _messageService.UpdateMessageAsync(id, saveMessage);

            if (!result.Success)
                return BadRequest(result.Message);

            return result.MessageDTO;
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<FromMessageDTO>> DeleteMessage(long id)
        {
            MessageResponse result = await _messageService.DeleteMessageAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            return result.MessageDTO;
        }

        [HttpGet("device/{deviceAddr}")]
        public async Task<IEnumerable<FromMessageDTO>> GetMessagesForDestDeviceAync(string deviceAddr)
        {
            return await _messageService.GetMessagesForDestDeviceAync(deviceAddr);
        }

        [HttpPost("device/{deviceAddr}")]
        public IEnumerable<FromMessageDTO> ExtractMessagesForDestDeviceFromMessageMem(string deviceAddr)
        {
            return _messageService.ExtractMessagesForDestDeviceFromMessageMem(deviceAddr);
        }
    }
}
