using TodoApp.Application.Common.DTOs;
using TodoApp.Application.Common.Interfaces;
using TodoApp.Application.Common.Models;

namespace TodoApp.Application.TodoItems.Queries.GetAllTodoItems;

public record GetAllTodoItemsQuery(Guid? Id) : IRequest<Result<List<TodoItemDto>>>;

public class GetAllTodoItemsQueryHandler(IApplicationDbContext context, IMapper mapper) : IRequestHandler<GetAllTodoItemsQuery, Result<List<TodoItemDto>>>
{
    public async Task<Result<List<TodoItemDto>>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
    {
        var existingTodo = await context.TodoItems.ToListAsync(cancellationToken);

        var res = mapper.Map<List<TodoItemDto>>(existingTodo);

        return Result<List<TodoItemDto>>.Success(res);
    }
}
