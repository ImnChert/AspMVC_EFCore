using AutoMapper;
using BLL.DTOs;
using HunterWeb.ViewModels;

namespace HunterWeb.Mappings
{
    public class AnimalViewModelProfile : Profile
    {
        public AnimalViewModelProfile()
        {
            CreateMap<AnimalViewModel, AnimalDTO>().ReverseMap();
        }
    }
}
