using AutoMapper;
using BLL.Services.UserServices;
using Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HunterWeb.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserController(IUserService userService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {

            var user = await _userService.DeleteUserAsync(new BLL.DTOs.UserDTO { Id = id });

            return RedirectToAction("IndexAsync", "Admin");
        }
    }
}
