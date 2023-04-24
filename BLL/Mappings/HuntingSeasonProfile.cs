using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace BLL.Mappings
{
    internal class HuntingSeasonProfile : Profile
    {
        public HuntingSeasonProfile()
        {
            CreateMap<HuntingSeason, HuntingSeasonDTO>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.InformationHuntingSeason!.Description))
                .ReverseMap();
        }
    }
}
