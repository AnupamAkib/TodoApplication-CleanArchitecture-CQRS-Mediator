namespace TodoApp.Application.Common.DTOs;

public record TodoItemDto(
    Guid Id,
    string Title,
    string? Description,
    string Status,
    string Priority,
    bool IsUrgent,
    DateTimeOffset CreatedAt,
    bool IsArchived
);
