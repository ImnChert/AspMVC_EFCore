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
    internal class InfoAnimalProfile : Profile
    {
        public InfoAnimalProfile()
        {
            CreateMap<InformationAnimal, InformationAnimalDTO>().ReverseMap();
        }
    }
}
