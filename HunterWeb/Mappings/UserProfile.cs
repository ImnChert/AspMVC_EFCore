using AutoMapper;
using BLL.DTOs;
using HunterWeb.ViewModels;

namespace HunterWeb.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<UserViewModel, UserDTO>().ReverseMap();
        }
    }
}
