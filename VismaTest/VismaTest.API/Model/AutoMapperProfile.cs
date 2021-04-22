using AutoMapper;
using VismaTest.Domain.DTOs;
using VismaTest.Domain.Entities;

namespace VismaTest.API.Model
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<RoleDto, Role>().ReverseMap();
            CreateMap<UserRoleDto, UserRole>().ReverseMap();
        }
    }
}
