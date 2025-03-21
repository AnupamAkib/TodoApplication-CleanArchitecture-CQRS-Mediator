using TodoApp.Application.Common.DTOs;
using TodoApp.Application.Common.Models;

namespace TodoApp.Application.TodoItems.Queries.GetAllTodoItems;

public record GetAllTodoItemsDto
{
    public PaginatedList<TodoItemDto>? Opened { get; set; }
    public PaginatedList<TodoItemDto>? Pending { get; set; }
    public PaginatedList<TodoItemDto>? Done { get; set; }
}
