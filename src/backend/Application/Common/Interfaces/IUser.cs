namespace TodoApp.Application.Common.Interfaces;

public interface IUser
{
    Guid? Id { get; }
    Guid UserId { get; }
    string? Name { get; }
    string? Email { get; }
}
