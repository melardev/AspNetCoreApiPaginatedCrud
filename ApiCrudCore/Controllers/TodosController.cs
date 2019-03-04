using System.Collections.Generic;
using System.Threading.Tasks;
using ApiCrudCore.Dtos.Responses.Todos;
using ApiCrudCore.Entities;
using ApiCrudCore.Enums;
using ApiCrudCore.Infrastructure.Services;
using ApiCrudCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace ApiCrudCore.Controllers
{
    [Route("api/[controller]")]
    public class TodosController : Controller
    {
        private readonly TodoService _todosService;

        public TodosController(TodoService todosService)
        {
            _todosService = todosService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTodos([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            var result = await _todosService.FetchMany(page, pageSize, TodoShow.All);
            return StatusCodeAndDtoWrapper.BuildSuccess(TodoListResponse.Build(result.Item2, Request.Path, page,
                pageSize, result.Item1));
        }

        [HttpGet]
        [Route("pending")]
        public async Task<IActionResult> GetPending([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            var result = await _todosService.FetchMany(page, pageSize, TodoShow.Pending);
            return StatusCodeAndDtoWrapper.BuildSuccess(TodoListResponse.Build(result.Item2, Request.Path, page,
                pageSize, result.Item1));
        }

        [HttpGet]
        [Route("completed")]
        public async Task<IActionResult> GetCompleted([FromQuery] int page = 1, [FromQuery] int pageSize = 5)
        {
            var result = await _todosService.FetchMany(page, pageSize, TodoShow.Completed);
            return StatusCodeAndDtoWrapper.BuildSuccess(TodoListResponse.Build(result.Item2, Request.Path, page,
                pageSize, result.Item1));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetTodoDetails(int id) =>
            StatusCodeAndDtoWrapper.BuildSuccess(TodoDetailsDto.Build(await _todosService.Get(id)));

        [HttpPost]
        public async Task<IActionResult> CreateTodo([FromBody] Todo todo)
        {
            await _todosService.CreateTodo(todo);
            return StatusCodeAndDtoWrapper.BuildSuccess(TodoDetailsDto.Build(todo), "Todo Created Successfully");
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateTodo(int id, [FromBody] Todo todo) =>
            StatusCodeAndDtoWrapper.BuildSuccess(TodoDetailsDto.Build(await _todosService.Update(id, todo)),
                "Todo Updated Successfully");


        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteTodo(int id)
        {
            EntityEntry<Todo> result = _todosService.Delete(id);
            return StatusCodeAndDtoWrapper.BuildSuccess("Todo Deleted Successfully");
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteAll()
        {
            await _todosService.DeleteAll();
            return StatusCodeAndDtoWrapper.BuildSuccess("Todos Deleted Successfully");
        }
    }
}