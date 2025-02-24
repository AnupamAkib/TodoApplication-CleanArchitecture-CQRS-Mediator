using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Common.DTOs;
using TodoApp.Application.Common.Models;
using TodoApp.Application.TodoItems.Queries.GetAllTodoItems;

namespace TodoApp.Web.Controllers;

public class TodoController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<Result<PaginatedList<TodoItemDto>>>> GetAllTodoItems(
        [FromQuery] GetAllTodoItemsQuery query)
    {
        var result = await Mediator.Send(query);

        return result.Succeeded ? Ok(result) : BadRequest(result);
    }
}
