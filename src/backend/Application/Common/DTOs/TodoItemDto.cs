namespace TodoApp.Application.Common.DTOs;

public record TodoItemDto(
    Guid Id,
    string Title,
    string? Description,
    string Status,
    string Priority,
    bool IsUrgent,
    DateTimeOffset Created,
    bool? IsArchived
);
