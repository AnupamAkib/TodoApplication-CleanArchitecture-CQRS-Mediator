using Domain.Common.Enums;
using TodoApp.Application.Common.DTOs;
using TodoApp.Application.Common.Models;

namespace TodoApp.Application.TodoItems.Queries.GetAllTodoItems;

public record GetAllTodoItemsQuery(Guid? Id) : IRequest<Result<TodoItemDto>>;

public class GetAllTodoItemsQueryHandler : IRequestHandler<GetAllTodoItemsQuery, Result<TodoItemDto>>
{
    public async Task<Result<TodoItemDto>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
    {
        var _todo = new TodoItemDto(
            Id: Guid.NewGuid(),
            Title: "Hello World",
            Description: "Moving arround the world!",
            Status: TodoStatus.Pending.ToString(),
            Priority: Priority.Low.ToString(),
            IsUrgent: true,
            CreatedAt: DateTime.Now,
            IsArchived: false
        );

        return await Task.FromResult(Result<TodoItemDto>.Success(_todo));
    }
}
