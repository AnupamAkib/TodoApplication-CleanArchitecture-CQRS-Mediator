using Application.UnitTests.Common;
using TodoApp.Application.TodoItems.Queries.GetAllTodoItems;

namespace Application.UnitTests.TodoItems.Queries.GetAllTodoItems;

[TestFixture]
public class TestGetAllTodoItemsQueryHandler : CommandTestBase
{
    private readonly GetAllTodoItemsQueryHandler _handler;

    public TestGetAllTodoItemsQueryHandler()
    {
        _handler = new GetAllTodoItemsQueryHandler(_context, _mapper);
    }

    [Test]
    public async Task Handle_GetAllTodoItems_Success()
    {
        var query = new GetAllTodoItemsQuery();

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        result.Value.Should().NotBeNull();
        result.Value?.Items.Should().HaveCount(2);
        result.Value?.Items.First().Title.Should().BeEquivalentTo(TestTitle1);
        result.Value?.Items.Skip(1).First().Title.Should().BeEquivalentTo(TestTitle2);
    }
}
