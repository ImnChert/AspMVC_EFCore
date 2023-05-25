using AutoMapper;
using BLL.DTOs;
using Identity.Entities;

namespace BLL.Mappings
{
    internal class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserDTO>().ReverseMap();
        }
    }
}
