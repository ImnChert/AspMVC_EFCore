using AutoMapper;
using BLL.DTOs;
using HunterWeb.ViewModels;

namespace HunterWeb.Mappings
{
    public class InfoHuntingSeasonViewModelProfile : Profile
    {
        public InfoHuntingSeasonViewModelProfile()
        {
            CreateMap<InformationHuntingSeasonDTO, InfoHuntingSeasonViewModel>().ReverseMap();
        }
    }
}
