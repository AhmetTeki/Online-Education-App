using AutoMapper;
using OnlineEducation.DTO.DTOs.CourseRegisterDtos;
using OnlineEducation.Entity.Entities;

namespace OnlineEducation.API.Mapping
{
    public class CourseRegisterMapping :Profile
    {
        public CourseRegisterMapping()
        {
            CreateMap<CreateCourseRegisterDto, CourseRegister>().ReverseMap();
            CreateMap<UpdateCourseRegisterDto, CourseRegister>().ReverseMap();
            CreateMap<ResultCourseRegisterDto, CourseRegister>().ReverseMap();
        }
    }
}
