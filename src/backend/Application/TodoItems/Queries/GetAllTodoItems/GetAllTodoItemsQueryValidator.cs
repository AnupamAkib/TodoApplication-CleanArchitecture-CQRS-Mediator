namespace TodoApp.Application.TodoItems.Queries.GetAllTodoItems;

public class GetAllTodoItemsQueryValidator : AbstractValidator<GetAllTodoItemsQuery>
{
    public GetAllTodoItemsQueryValidator()
    {
        RuleFor(x => x.PageNumber)
            .GreaterThan(0).WithMessage("PageNumber should be greater than 0.");

        RuleFor(x => x.PageSize)
            .GreaterThan(0).WithMessage("PageSize should be greater than 0.");
    }
}
