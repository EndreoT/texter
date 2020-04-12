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
using Texter.Services.MessageServices;
using Texter.DataTransferObject;
using Texter.ExtensionMethods;
using Texter.Domain.Services.Communication;

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
        public async Task<IEnumerable<FromMessageDTO>> GetMessages()
        {
            return await _messageService.ListAsync();
        }

        [HttpGet("{id}")]
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
        public async Task<IActionResult> CreateMessage([FromBody] SaveMessageDTO saveMessageDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());


            MessageResponse result = await _messageService.CreateMessageAsync(saveMessageDTO);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.MessageDTO);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMessage(long id, SaveMessageDTO saveMessage)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            MessageResponse result = await _messageService.UpdateMessageAsync(id, saveMessage);

            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.MessageDTO);
        }

        //    [HttpPost]
        //    public async Task<ActionResult<TodoItemDTO>> CreateTodoItem(TodoItemDTO todoItemDTO)
        //    {
        //        var todoItem = new TodoItem
        //        {
        //            IsComplete = todoItemDTO.IsComplete,
        //            Name = todoItemDTO.Name
        //        };

        //        _context.Messages.Add(todoItem);
        //        await _context.SaveChangesAsync();

        //        return CreatedAtAction(
        //            nameof(GetTodoItem),
        //            new { id = todoItem.Id },
        //            ItemToDTO(todoItem));
        //    }

        //    [HttpDelete("{id}")]
        //    public async Task<IActionResult> DeleteTodoItem(long id)
        //    {
        //        var todoItem = await _context.Messages.FindAsync(id);

        //        if (todoItem == null)
        //        {
        //            return NotFound();
        //        }

        //        _context.Messages.Remove(todoItem);
        //        await _context.SaveChangesAsync();

        //        return NoContent();
        //    }

        //    private bool TodoItemExists(long id) =>
        //         _context.Messages.Any(e => e.Id == id);

        //    private static TodoItemDTO ItemToDTO(TodoItem todoItem) =>
        //        new TodoItemDTO
        //        {
        //            Id = todoItem.Id,
        //            Name = todoItem.Name,
        //            IsComplete = todoItem.IsComplete
        //        };
    }

}
