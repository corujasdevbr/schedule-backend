using AutoMapper;
using CorujasDev.Schedulive.Application.DTOs;
using CorujasDev.Schedulive.Domain.Entities;

namespace CorujasDev.Schedulive.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserDomain, UserDTO>().ReverseMap();

            CreateMap<CategoryDomain, CategoryDTO>().ReverseMap();
            CreateMap<LiveDomain, LiveDTO>().ReverseMap();
        }
    }
}
