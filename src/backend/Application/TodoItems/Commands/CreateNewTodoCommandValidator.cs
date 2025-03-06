namespace TodoApp.Application.TodoItems.Commands;

public class CreateNewTodoCommandValidator : AbstractValidator<CreateNewTodoCommand>
{
    public CreateNewTodoCommandValidator()
    {
        RuleFor(u => u.Title)
            .NotEmpty()
            .WithMessage("Title shouldn't be empty")
            .MaximumLength(200)
            .WithMessage("Title length should be less than 200 characters");

        RuleFor(u => u.Description)
            .MaximumLength(5000);
    }
}
