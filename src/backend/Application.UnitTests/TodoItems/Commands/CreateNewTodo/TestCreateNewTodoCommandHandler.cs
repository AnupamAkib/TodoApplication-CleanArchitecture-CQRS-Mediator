using Application.UnitTests.Common;
using TodoApp.Application.TodoItems.Commands;

namespace Application.UnitTests.TodoItems.Commands.CreateNewTodo;

[TestFixture]
public class TestCreateNewTodoCommandHandler : CommandTestBase
{
    private readonly CreateNewTodoCommandHandler _handler;

    public TestCreateNewTodoCommandHandler()
    {
        _handler = new CreateNewTodoCommandHandler(_context, _mapper);
    }

    [Test]
    public async Task Handle_WhenExistingTodoFoundWithSameTitle_ReturnFailure()
    {
        var command = new CreateNewTodoCommand(Title: TestTodoTitle2, Description: null);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        result.Succeeded.Should().BeFalse();
        result.Value?.Should().BeNull();
        result.Error.Should().Be("Todo with similar title already exist. Please check your active or archived todo items");
    }

    [Test]
    public async Task Handle_FoundUniqueTitle_ReturnSuccess()
    {
        var command = new CreateNewTodoCommand(Title: TestTodoTitle3, Description: null);

        // Act
        var result = await _handler.Handle(command, CancellationToken.None);

        result.Succeeded.Should().BeTrue();
        result.Value?.Should().NotBeNull();
        result.Value?.Title.Should().BeEquivalentTo(TestTodoTitle3);
    }
}
