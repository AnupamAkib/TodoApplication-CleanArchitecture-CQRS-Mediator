using TodoApp.Application.Common.Interfaces;

namespace TodoApp.Web.Services;

public class CurrentUser : IUser
{
    public Guid? Id => null;
    public Guid UserId => Guid.Empty;
    public string? Email => null;
    public string? Name => null;
}
