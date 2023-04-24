using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace BLL.Mappings
{
    internal class AnimalDetailProfile : Profile
    {
        public AnimalDetailProfile()
        {
            CreateMap<Animal, AnimalDetailDTO>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.InformationAnimal!.Description))
                .ForMember(dest => dest.AddtionalName, opt => opt.MapFrom(src => src.InformationAnimal!.AddtionalName))
                .ReverseMap();
        }
    }
}
