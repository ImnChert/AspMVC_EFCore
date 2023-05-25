using AutoMapper;
using BLL.Services.UserServices;
using HunterWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace HunterWeb.Controllers
{
    public class AdminController : Controller
    {
        private IUserService _userService;
        private readonly IMapper _mapper;

        public AdminController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<IActionResult> IndexAsync()
        {
            try
            {
                var users = await _userService.GetAllAsync();

                users = users.Where(u => (u.Email != User.Identity!.Name) && (u.Hide != 1)).ToList();

                var mapperModel = _mapper.Map<List<UserViewModel>>(users);

                return View(mapperModel);
            }
            catch
            {
                return View(new List<UserViewModel>());
            }
        }

        public async Task<IActionResult> DetailInfo(int id)
        {
            try
            {
                var user = await _userService.GetUserByIdAsync(id);

                var mapperModel = _mapper.Map<UserViewModel>(user);

                return View(mapperModel);
            }
            catch
            {
                return View(new UserViewModel());
            }
        }

        [HttpGet]
        public async Task<List<UserViewModel>> FindUserByEmail(string value)
        {
            try
            {
                var users = await _userService.GetAllAsync();

                users = users.Where(u => (u.Email != User.Identity!.Name)
                && (u.Hide != 1)
                && u.Email.Contains(value))
                    .ToList();


                var mapperModel = _mapper.Map<List<UserViewModel>>(users);

                return mapperModel;
            }
            catch
            {
                return new List<UserViewModel>();
            }
        }
    }
}
