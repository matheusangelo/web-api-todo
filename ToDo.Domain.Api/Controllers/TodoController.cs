using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Repositories;
using ToDo.Domain.Entities;

namespace ToDo.Domain.Api.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {

        private readonly ILogger<TodoController> _logger;
        private readonly ITodoRepository _todoRepository;
        public TodoController(ILogger<TodoController> logger, ITodoRepository todoRepository)
        {
            _logger = logger;
            _todoRepository = todoRepository;
        }

        [HttpPost]
        public async Task<ActionResult> PostTodo(
            [FromBody] CreateToDoCommand command,
            [FromServices] HandlerCreateToDoItem handler
            )
        {
            command.User = "matheusangelo";
            var result = (CommandResult)handler.Handle(command);
            
            if (!result.Success){
                return BadRequest(result);
            }

            return Ok(result);
        }


        [HttpGet]
        [Route("{user}")]
        public async Task<IList<TodoItem>> GetAllTodos(string user)
        {
            return _todoRepository.GetAllUsers(user);
        }

    }
}
