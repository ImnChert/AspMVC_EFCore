using AutoMapper;
using BLL.DTOs;
using BLL.Services.AccountServices;
using HunterWeb.ViewModels;
using Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HunterWeb.Controllers
{
    public class AccountController : Controller
    {
        private IAccountService _accountService;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(IAccountService accountService, IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _accountService = accountService;
            _mapper = mapper;
            _userManager = userManager;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SignOut(UserViewModel user)
        {
            try
            {
                await _accountService.LogoutAsync();
                return RedirectToAction("Index", "Animal");
            }
            catch
            {
                return RedirectToAction("Index", "Animal");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(UserViewModel user)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(user);
                }

                var result = await _accountService.LoginAsync(user.Email, user.Password);

                if(result == false)
                {
                    return View("~/Views/Product/_Error.cshtml");
                }

                return RedirectToAction("Check");
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Check()
        {
            try
            {
                var userr = await _userManager.GetUserAsync(User);
                if(userr.Hide == 1)
                {
                    return RedirectToAction("SignOut", userr);
                }

                return RedirectToAction("Index", "Home");
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserViewModel user)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return View(user);
                }
                var appUser = _mapper.Map<UserDTO>(user);

                var result = await _accountService.RegisterAsync(appUser, user.Password, "User");

                if(!result)
                {
                    return View("~/Views/Product/_Error.cshtml");
                }

                return RedirectToAction("Check");
            }
            catch
            {
                return View();
            }
        }
    }
}
