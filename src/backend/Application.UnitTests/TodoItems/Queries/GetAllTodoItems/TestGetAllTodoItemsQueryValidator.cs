using TodoApp.Application.TodoItems.Queries.GetAllTodoItems;

namespace Application.UnitTests.TodoItems.Queries.GetAllTodoItems;

[TestFixture]
public class TestGetAllTodoItemsQueryValidator
{
    private readonly GetAllTodoItemsQueryValidator _validator;

    public TestGetAllTodoItemsQueryValidator()
    {
        _validator = new GetAllTodoItemsQueryValidator();
    }

    [Test]
    public void Validate_WhenPageNumberIsNotPositiveNumber_ShouldReturnFailure()
    {
        var query = new GetAllTodoItemsQuery(PageNumber: -2);

        // Act
        var result = _validator.TestValidate(query);
        result.ShouldHaveValidationErrorFor(c => c.PageNumber)
            .WithErrorMessage("PageNumber should be greater than 0.");
    }

    [Test]
    public void Validate_WhenPageSizeIsNotPositiveNumber_ShouldReturnFailure()
    {
        var query = new GetAllTodoItemsQuery(PageSize: 0);

        // Act
        var result = _validator.TestValidate(query);
        result.ShouldHaveValidationErrorFor(c => c.PageSize)
            .WithErrorMessage("PageSize should be greater than 0.");
    }
}
