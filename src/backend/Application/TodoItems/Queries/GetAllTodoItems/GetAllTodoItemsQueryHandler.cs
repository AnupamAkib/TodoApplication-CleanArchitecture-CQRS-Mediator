using TodoApp.Application.Common.DTOs;
using TodoApp.Application.Common.Interfaces;
using TodoApp.Application.Common.Mappings;
using TodoApp.Application.Common.Models;

namespace TodoApp.Application.TodoItems.Queries.GetAllTodoItems;

public record GetAllTodoItemsQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string SearchText = "")
    : IRequest<Result<PaginatedList<TodoItemDto>>>;

public class GetAllTodoItemsQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetAllTodoItemsQuery, Result<PaginatedList<TodoItemDto>>>
{
    public async Task<Result<PaginatedList<TodoItemDto>>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
    {
        var existingTodo = context.TodoItems.AsQueryable();

        //Todo: Implement SearchText query & search by TodoItem Id, filter (search by priority, urgency, date etc)

        var res = await existingTodo.OrderByDescending(todo => todo.Priority)
            .ProjectTo<TodoItemDto>(mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);

        return Result<PaginatedList<TodoItemDto>>.Success(res);
    }
}
