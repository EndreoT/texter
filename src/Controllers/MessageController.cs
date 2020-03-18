using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Texter.Domain.Models;
using Texter.Persistence.Context;
using Texter.Domain.ServiceInterface;
using Texter.Services.MessageServices;
using Texter.DataTransferObject;

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
        public async Task<IEnumerable<MessageDTO>> GetMessages()
        {
            return await _messageService.ListAsync();
        }

        //    [HttpGet("{id}")]
        //    public async Task<ActionResult<TodoItemDTO>> GetTodoItem(long id)
        //    {
        //        var todoItemDTO = await _context.Messages
        //            .Where(x => x.Id == id)
        //            .Select(x => ItemToDTO(x))
        //            .SingleAsync();

        //        if (todoItemDTO == null)
        //        {
        //            return NotFound();
        //        }

        //        return todoItemDTO;
        //    }

        //    [HttpPut("{id}")]
        //    public async Task<IActionResult> UpdateTodoItem(long id, TodoItemDTO todoItemDTO)
        //    {
        //        if (id != todoItemDTO.Id)
        //        {
        //            return BadRequest();
        //        }

        //        var todoItem = await _context.Messages.FindAsync(id);
        //        if (todoItem == null)
        //        {
        //            return NotFound();
        //        }

        //        todoItem.Name = todoItemDTO.Name;
        //        todoItem.IsComplete = todoItemDTO.IsComplete;

        //        try
        //        {
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException) when (!TodoItemExists(id))
        //        {
        //            return NotFound();
        //        }

        //        return NoContent();
        //    }

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
