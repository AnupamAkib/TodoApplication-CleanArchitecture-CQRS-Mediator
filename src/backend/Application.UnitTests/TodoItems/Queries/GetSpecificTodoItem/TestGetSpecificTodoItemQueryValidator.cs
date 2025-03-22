using TodoApp.Application.TodoItems.Queries.GetSpecificTodoItem;

namespace Application.UnitTests.TodoItems.Queries.GetSpecificTodoItem;

[TestFixture]
public class TestGetSpecificTodoItemQueryValidator
{
    private readonly GetSpecificTodoItemQueryValidator validator;

    public TestGetSpecificTodoItemQueryValidator()
    {
        validator = new GetSpecificTodoItemQueryValidator();
    }

    [Test]
    public void Validate_WhenTodoIdIsEmpty_ShouldReturnFailure()
    {
        var query = new GetSpecificTodoItemQuery(Id: Guid.Empty);

        // Act
        var result = validator.TestValidate(query);

        result.ShouldHaveValidationErrorFor(x => x.Id)
            .WithErrorMessage("Todo ID must not be empty");
    }
}
