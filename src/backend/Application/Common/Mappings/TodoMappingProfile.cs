using Domain.Entities;
using TodoApp.Application.Common.DTOs;

namespace TodoApp.Application.Common.Mappings;

public class TodoMappingProfile : Profile
{
    public TodoMappingProfile()
    {
        CreateMap<Todo, TodoItemDto>();
    }
}
