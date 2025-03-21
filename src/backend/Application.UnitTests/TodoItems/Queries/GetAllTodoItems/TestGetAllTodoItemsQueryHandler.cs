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

        result.Succeeded.Should().BeTrue();
        result.Value.Should().NotBeNull();
        result.Value?.Opened?.Items.Should().HaveCount(2);
        result.Value?.Opened?.Items.First().Title.Should().BeEquivalentTo(TestTodoTitle1);
        result.Value?.Opened?.Items.Skip(1).First().Title.Should().BeEquivalentTo(TestTodoTitle2);
        result.Value?.Opened?.Items.Skip(1).First().Priority.Should().BeEquivalentTo(TestPriority2.ToString());
        result.Error?.Should().BeNull();
    }

    [Test]
    public async Task Handle_GetTodoItemsBySearchString_Success()
    {
        var query = new GetAllTodoItemsQuery(SearchText: TestTodoTitle1);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        result.Succeeded.Should().BeTrue();
        result.Value.Should().NotBeNull();
        result.Value?.Opened?.Items.Should().HaveCount(1);
        result.Value?.Opened?.Items.First().Title.Should().BeEquivalentTo(TestTodoTitle1);
        result.Error?.Should().BeNull();
    }

    [Test]
    public async Task Handle_GetTodoItemsByPriority_Success()
    {
        var query = new GetAllTodoItemsQuery(Priority: TestPriority2);

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        result.Succeeded.Should().BeTrue();
        result.Value.Should().NotBeNull();
        result.Value?.Opened?.Items.Should().HaveCount(1);
        result.Value?.Opened?.Items.First().Title.Should().BeEquivalentTo(TestTodoTitle2);
        result.Error?.Should().BeNull();
    }

    [Test]
    public async Task Handle_WhenNoResultFound_Success()
    {
        var query = new GetAllTodoItemsQuery(SearchText: "something that doesn't exist");

        // Act
        var result = await _handler.Handle(query, CancellationToken.None);

        result.Succeeded.Should().BeTrue();
        result.Value.Should().NotBeNull();
        result.Value?.Opened?.Items.Should().BeEmpty();
        result.Value?.Pending?.Items.Should().BeEmpty();
        result.Value?.Done?.Items.Should().BeEmpty();
        result.Error?.Should().BeNull();
    }
}
