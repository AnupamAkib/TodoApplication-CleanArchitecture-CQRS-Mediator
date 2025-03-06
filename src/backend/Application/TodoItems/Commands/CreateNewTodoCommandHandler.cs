using Domain.Common.Enums;
using Domain.Entities;
using TodoApp.Application.Common.DTOs;
using TodoApp.Application.Common.Interfaces;
using TodoApp.Application.Common.Models;

namespace TodoApp.Application.TodoItems.Commands;

public record CreateNewTodoCommand(
    string Title,
    string? Description,
    Priority Priority = Priority.Normal,
    bool IsUrgent = false) : IRequest<Result<TodoItemDto>>;

public class CreateNewTodoCommandHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<CreateNewTodoCommand, Result<TodoItemDto>>
{
    public async Task<Result<TodoItemDto>> Handle(CreateNewTodoCommand request, CancellationToken cancellationToken)
    {
        var isExist = await context.TodoItems.AnyAsync(todo => todo.Title.Trim() == request.Title.Trim());

        if (isExist)
        {
            return Result<TodoItemDto>.Failure(["Todo with similar title already exist. Please check your active or archived todo items"]);
        }

        var todo = new Todo
        {
            Title = request.Title.Trim(),
            Description = request.Description,
            Priority = request.Priority,
            IsUrgent = request.IsUrgent
        };

        var createdTodo = await context.TodoItems.AddAsync(todo, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        var result = mapper.Map<TodoItemDto>(createdTodo.Entity);

        return Result<TodoItemDto>.Success(result);
    }
}
