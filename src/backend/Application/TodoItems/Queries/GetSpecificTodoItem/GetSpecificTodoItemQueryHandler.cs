using TodoApp.Application.Common.DTOs;
using TodoApp.Application.Common.Interfaces;
using TodoApp.Application.Common.Models;

namespace TodoApp.Application.TodoItems.Queries.GetSpecificTodoItem;

public record GetSpecificTodoItemQuery(Guid Id) : IRequest<Result<TodoItemDto>>;

public class GetSpecificTodoItemQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetSpecificTodoItemQuery, Result<TodoItemDto>>
{
    public async Task<Result<TodoItemDto>> Handle(GetSpecificTodoItemQuery request, CancellationToken cancellationToken)
    {
        var todo = await context.TodoItems.FindAsync(request.Id, cancellationToken);

        if (todo is null)
        {
            return Result<TodoItemDto>.Failure(["Todo item doesn't exist"]);
        }

        var result = mapper.Map<TodoItemDto>(todo);

        return Result<TodoItemDto>.Success(result);
    }
}
