using AutoMapper;
using BLL.DTOs;
using HunterWeb.ViewModels;

namespace HunterWeb.Mappings
{
    public class InfoAnimalViewModelProfile : Profile
    {
        public InfoAnimalViewModelProfile()
        {
            CreateMap<InfoAnimalViewModel, InformationAnimalDTO>().ReverseMap();
        }
    }
}
