using Domain.Common.Enums;
using Domain.Entities;

namespace Domain.UnitTests;

public partial class ConstantData
{
    public static readonly Guid TestTodoItemGuid1 = Guid.NewGuid();
    public static readonly string TestTodoTitle1 = "TestTodoTitle1";

    public static readonly Guid TestTodoItemGuid2 = Guid.NewGuid();
    public static readonly string TestTodoTitle2 = "TestTodoTitle2";
    public static readonly Priority TestPriority2 = Priority.High;

    public static readonly Guid TestTodoItemGuid3 = Guid.NewGuid();
    public static readonly string TestTodoTitle3 = "TestTodoTitle3";

    public static Todo TestTodo1 = new()
    {
        Id = TestTodoItemGuid1,
        Title = TestTodoTitle1
    };

    public static Todo TestTodo2 = new()
    {
        Id = TestTodoItemGuid2,
        Title = TestTodoTitle2,
        Priority = TestPriority2
    };
}
