using AutoMapper;
using TodoAppWeek4.Models;
using TodoAppWeek4.ViewModels;

namespace TodoAppWeek4.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Todo, TodoViewModel>();
    }
}