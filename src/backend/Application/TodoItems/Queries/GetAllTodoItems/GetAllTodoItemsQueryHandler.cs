using Domain.Common.Enums;
using Domain.Entities;
using TodoApp.Application.Common.DTOs;
using TodoApp.Application.Common.Interfaces;
using TodoApp.Application.Common.Mappings;
using TodoApp.Application.Common.Models;

namespace TodoApp.Application.TodoItems.Queries.GetAllTodoItems;

public record GetAllTodoItemsQuery(
    int PageNumber = 1,
    int PageSize = 10,
    string SearchText = "")
    : IRequest<Result<GetAllTodoItemsDto>>;

public class GetAllTodoItemsQueryHandler(IApplicationDbContext context, IMapper mapper)
    : IRequestHandler<GetAllTodoItemsQuery, Result<GetAllTodoItemsDto>>
{
    public async Task<Result<GetAllTodoItemsDto>> Handle(GetAllTodoItemsQuery request, CancellationToken cancellationToken)
    {
        var existingTodo = context.TodoItems.AsQueryable();

        if (request.SearchText != null)
        {
            existingTodo = existingTodo
                .Where(t => t.Title.ToLower().Contains(request.SearchText.ToLower()) ||
                        (t.Description ?? "").ToLower().Contains(request.SearchText.ToLower()));
        }

        var todoItemsWithStatus = new GetAllTodoItemsDto
        {
            Opened = await GetTodoByStatus(existingTodo, TodoStatus.Opened, mapper, request),
            Pending = await GetTodoByStatus(existingTodo, TodoStatus.Pending, mapper, request),
            Done = await GetTodoByStatus(existingTodo, TodoStatus.Done, mapper, request)
        };

        if (todoItemsWithStatus is null)
        {
            return Result<GetAllTodoItemsDto>.Failure(["Not found"]);
        }

        //Todo: Implement search by TodoItem Id, filter (search by priority, urgency, date etc)

        return Result<GetAllTodoItemsDto>.Success(todoItemsWithStatus);
    }

    private async Task<PaginatedList<TodoItemDto>> GetTodoByStatus(
        IQueryable<Todo> todos,
        TodoStatus status,
        IMapper mapper,
        GetAllTodoItemsQuery request)
    {
        return await todos
            .Where(t => t.Status == status)
            .ProjectTo<TodoItemDto>(mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
