using Domain.Entities;

namespace Domain.UnitTests;

public partial class ConstantData
{
    public static readonly Guid TestTodoItemGuid1 = Guid.NewGuid();
    public static readonly string TestTitle1 = "TestTodoTitle1";

    public static readonly Guid TestTodoItemGuid2 = Guid.NewGuid();
    public static readonly string TestTitle2 = "TestTodoTitle2";

    public static Todo TestTodo1 = new()
    {
        Id = TestTodoItemGuid1,
        Title = TestTitle1
    };

    public static Todo TestTodo2 = new()
    {
        Id = TestTodoItemGuid2,
        Title = TestTitle2
    };
}
