namespace TodoApp.Application.TodoItems.Queries.GetSpecificTodoItem;

public class GetSpecificTodoItemQueryValidator : AbstractValidator<GetSpecificTodoItemQuery>
{
    public GetSpecificTodoItemQueryValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithMessage("Todo ID must not be empty");
    }
}
