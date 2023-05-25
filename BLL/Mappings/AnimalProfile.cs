using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace BLL.Mappings
{
    internal class AnimalProfile : Profile
    {
        public AnimalProfile()
        {
            CreateMap<Animal, AnimalDTO>().ReverseMap();

            CreateMap<Animal, AnimalDetailDTO>()
               .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.InformationAnimal!.Description))
               .ReverseMap();
        }
    }
}