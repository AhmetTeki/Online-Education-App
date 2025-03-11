using AutoMapper;
using OnlineEducation.DTO.DTOs.SubscribeDtos;
using OnlineEducation.Entity.Entities;

namespace OnlineEducation.API.Mapping
{
    public class SubscribeMapping : Profile
    {
        public SubscribeMapping()
        {
            CreateMap<CreateSubscribeDto, Subscriber>().ReverseMap();
            CreateMap<UpdateSubscribeDto, Subscriber>().ReverseMap();
        }
    }
}
