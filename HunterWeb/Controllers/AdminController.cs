using AutoMapper;
using BLL.Services.UserServices;
using HunterWeb.ViewModels;
using Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HunterWeb.Controllers
{
    public class AdminController : Controller
    {
        private IUserService _userService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(IUserService userService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var users = await _userService.GetAllAsync();

            users = users.Where(u => (u.Email != User.Identity!.Name) && (u.Hide != 1)).ToList();

            var mapperModel = _mapper.Map<List<UserViewModel>>(users);

            return View(mapperModel);
        }

        public async Task<IActionResult> DetailInfo(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            var mapperModel = _mapper.Map<UserViewModel>(user);

            return View(mapperModel);
        }

        [HttpGet]
        public async Task<List<UserViewModel>> FindUserByEmail(string value)
        {
            var users = await _userService.GetAllAsync();

            users = users.Where(u => (u.Email != User.Identity!.Name)
            && (u.Hide != 1)
            && u.Email.Contains(value))
                .ToList();


            var mapperModel = _mapper.Map<List<UserViewModel>>(users);

            return mapperModel;
        }
    }
}
