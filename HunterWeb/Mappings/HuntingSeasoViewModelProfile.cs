using AutoMapper;
using BLL.DTOs;
using HunterWeb.ViewModels;

namespace HunterWeb.Mappings
{
    public class HuntingSeasoViewModelProfile : Profile
    {
        public HuntingSeasoViewModelProfile()
        {
            CreateMap<HuntingSeasonDTO, HuntingSeasonViewModel>().ReverseMap();
        }
    }
}
