using Application.UnitTests.Common;
using TodoApp.Application.TodoItems.Commands;

namespace Application.UnitTests.TodoItems.Commands.CreateNewTodo;

[TestFixture]
public class TestCreateNewTodoCommandValidator : CommandTestBase
{
    private readonly CreateNewTodoCommandValidator _validator;

    public TestCreateNewTodoCommandValidator()
    {
        _validator = new CreateNewTodoCommandValidator();
    }

    [Test]
    public void Validate_WhenTitleIsEmpty_ReturnFailure()
    {
        var command = new CreateNewTodoCommand(Title: string.Empty, Description: null);

        // Act
        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(u => u.Title)
            .WithErrorMessage("Title shouldn't be empty");
    }

    [Test]
    public void Validate_WhenTitleIsTooLong_ReturnFailure()
    {
        var command = new CreateNewTodoCommand(Title: new string('a', 201), Description: null);

        // Act
        var result = _validator.TestValidate(command);

        result.ShouldHaveValidationErrorFor(u => u.Title)
            .WithErrorMessage("Title length should be less than 200 characters");
    }
}
