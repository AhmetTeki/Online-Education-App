using AutoMapper;
using OnlineEducation.Entity.Entities;
using OnlineEducation.WebUI.DTOs.RoleDtos;

namespace OnlineEducation.WebUI.Mappings
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<AppRole, ResultRoleDto>().ReverseMap();
            CreateMap<AppRole, CreateRoleDto>().ReverseMap();
            CreateMap<AppRole, UpdateRoleDto>().ReverseMap();
        }
    }
}
