using AutoMapper;
using BLL.DTOs;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Mappings
{
    internal class InfoHuntingSeasonProfile : Profile
    {
        public InfoHuntingSeasonProfile()
        {
            CreateMap<InformationHuntingSeason, InformationHuntingSeasonDTO>().ReverseMap();
        }
    }
}
