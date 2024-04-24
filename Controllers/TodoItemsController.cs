using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Models;
using TodoApi.Services;

namespace TodoApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly TodoItemsService _todoItemsService;

        public TodoItemsController(TodoItemsService todoItemsService)
        {
            _todoItemsService = todoItemsService;
        }

        // GET: api/TodoItems
        [HttpGet]
        //[Route("GetTodoItems")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
        {
            var todoItems = await _todoItemsService.GetTodoItemsAsync();
            return Ok(todoItems);
        }

        // GET: api/TodoItems/5
        [HttpGet("{id}")]
        //[Route("GetTodoItem")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var todoItem = await _todoItemsService.GetTodoItemAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return todoItem;
        }

        // POST: api/TodoItems
        [HttpPost]
        //[Route("PostTodoItem")]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItem todoItem)
        {
            await _todoItemsService.CreateTodoItemAsync(todoItem);
            return CreatedAtAction(nameof(GetTodoItem), new { id = todoItem.Id }, todoItem);
        }

        // PUT: api/TodoItems/5
        [HttpPut("{id}")]
        //[Route("PutTodoItem")]
        public async Task<IActionResult> PutTodoItem(long id, TodoItem todoItem)
        {
            if (id != todoItem.Id)
            {
                return BadRequest();
            }
            await _todoItemsService.UpdateTodoItemAsync(todoItem);
            return NoContent();
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        //[Route("DeleteTodoItem")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            await _todoItemsService.DeleteTodoItemAsync(id);
            return NoContent();
        }

        [HttpPost]
        [Route("SortDataByString")]
        public async Task<ActionResult<IEnumerable<NewSortedModel>>> SortDataByString([FromBody] string input)
        {
            if (input.Length > 99)
            {
                return BadRequest("String value over 99");
            }
            var sortedString = await _todoItemsService.SortDataByStringDL(input);

            return Ok(sortedString);
        }
    }
}
