using Microsoft.AspNetCore.Mvc;
using TodoApp.Application.Common.DTOs;
using TodoApp.Application.Common.Models;
using TodoApp.Application.TodoItems.Queries.GetAllTodoItems;

namespace TodoApp.Web.Controllers;

public class TodoController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<Result<TodoItemDto>>> GetAllTodoItems(Guid? id)
    {
        var result = await Mediator.Send(new GetAllTodoItemsQuery(id));

        return Ok(result);
    }
}
