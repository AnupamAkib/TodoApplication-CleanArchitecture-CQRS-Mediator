using Application.UnitTests.Common;
using TodoApp.Application.TodoItems.Queries.GetSpecificTodoItem;

namespace Application.UnitTests.TodoItems.Queries.GetSpecificTodoItem;

[TestFixture]
public class TestGetSpecificTodoItemQueryHandler : CommandTestBase
{
    private readonly GetSpecificTodoItemQueryHandler _handler;

    public TestGetSpecificTodoItemQueryHandler()
    {
        _handler = new GetSpecificTodoItemQueryHandler(_context, _mapper);
    }

    [Test]
    public async Task Handle_WhenValidGuidProvided_ReturnSuccess()
    {
        var query = new GetSpecificTodoItemQuery(Id: TestTodoItemGuid1);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        result.Succeeded.Should().BeTrue();
        result.Error?.Should().BeNullOrEmpty();
        result.Value?.Title.Should().BeEquivalentTo(TestTodoTitle1);
    }

    [Test]
    public async Task Handle_WhenInvalidGuidProvided_ReturnFailure()
    {
        var query = new GetSpecificTodoItemQuery(Id: Guid.NewGuid());

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        result.Succeeded.Should().BeFalse();
        result.Error?.Should().BeEquivalentTo("Todo item doesn't exist");
        result.Value?.Should().BeNull();
    }

    [Test]
    public async Task Handle_WhenArchivedTodoGuidProvided_ReturnSuccess()
    {
        var query = new GetSpecificTodoItemQuery(Id: TestTodoItemGuid3);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        result.Succeeded.Should().BeTrue();
        result.Error?.Should().BeNull();
        result.Value?.Title.Should().BeEquivalentTo(TestTodoTitle3);
    }
}
