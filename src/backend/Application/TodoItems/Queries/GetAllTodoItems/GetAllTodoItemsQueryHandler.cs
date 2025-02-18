using TodoApp.Application.Common.DTOs;
using TodoApp.Application.Common.Interfaces;
using TodoApp.Application.Common.Models;

namespace TodoApp.Application.TodoItems.Queries.GetAllTodoItems;

public record GetAllTodoItemsQuery(Guid? Id) : IRequest<Result<TodoItemDto>>;

public class GetAllTodoItemsQueryHandler(IApplicationDbContext context) : IRequestHandler<GetAllTodoItemsQuery, Result<TodoItemDto>>
{
    public async Task<Result<TodoItemDto>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
    {
        var existingTodo = await context.TodoItems.FirstOrDefaultAsync(cancellationToken);

        if (existingTodo == null)
        {
            return Result<TodoItemDto>.Failure(["No todo item found"]);
        }

        var _todo = new TodoItemDto(
            Id: existingTodo.Id,
            Title: existingTodo.Title,
            Description: existingTodo.Description,
            Status: existingTodo.Status.ToString(),
            Priority: existingTodo.Priority.ToString(),
            IsUrgent: existingTodo.IsUrgent,
            IsArchived: existingTodo.IsArchived,
            CreatedAt: existingTodo.Created
        );

        return Result<TodoItemDto>.Success(_todo);
    }
}
