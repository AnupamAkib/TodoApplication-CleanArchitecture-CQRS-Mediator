using Domain.Entities;
using TodoApp.Application.Common.DTOs;

namespace TodoApp.Application.Common.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Todo, TodoItemDto>();
    }
}
