using AutoMapper;
using BLL.DTOs;
using DAL.Entities;
using HunterWeb.ViewModels;

namespace HunterWeb.Mappings
{
    public class ShortAnimalViewModelProfile : Profile
    {
        public ShortAnimalViewModelProfile()
        {
            CreateMap<ShortAnimalViewModel, AnimalDTO>().ReverseMap();
        }
    }
}
