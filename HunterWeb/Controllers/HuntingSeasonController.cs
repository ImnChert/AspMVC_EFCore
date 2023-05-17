using AutoMapper;
using BLL.DTOs;
using BLL.Services.HuntingSeasonService;
using HunterWeb.Models;
using HunterWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace HunterWeb.Controllers
{
    public class HuntingSeasonController : Controller
    {
        private readonly IHuntingSeasonService _huntingSeasonService;
        private readonly IMapper _mapper;

        public HuntingSeasonController(IHuntingSeasonService huntingSeasonService, IMapper mapper)
        {
            _huntingSeasonService = huntingSeasonService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(int animalId)
        {
            return View(new HuntingSeasonViewModel { AnimalId = animalId });
        }

        [HttpGet]
        public IActionResult Update(int id, int animalId, DateTime dateStart, DateTime dateEnd, string description)
        {
            var huntingSeason = new HuntingSeasonViewModel()
            {
                Id = id,
                AnimalId = animalId,
                DateStart = dateStart,
                DateEnd = dateEnd,
                Description = description
            };

            return View("Create", huntingSeason);
        }

        [HttpPost]
        public IActionResult CreateHuntingSeason(HuntingSeasonViewModel huntingSeason)
        {
            try
            {
                if(huntingSeason.Id != 0)
                    return RedirectToAction("UpdateHuntingSeason", "HuntingSeason", huntingSeason);

                var huntingSeasonDto = _mapper.Map<HuntingSeasonDTO>(huntingSeason);
                var x = _huntingSeasonService.CreateAsync(huntingSeasonDto).Result;

                return RedirectToAction("Info", "Animal", new { Id = huntingSeasonDto.AnimalId });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult UpdateHuntingSeason(HuntingSeasonViewModel huntingSeason)
        {
            try
            {
                var huntingSeasonDto = _mapper.Map<HuntingSeasonDTO>(huntingSeason);
                var x = _huntingSeasonService.UpdateAsync(huntingSeasonDto).Result;

                return RedirectToAction("Info", "Animal", new { Id = huntingSeasonDto.AnimalId });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Remove(int id, int animalId)
        {
            try
            {
                var huntingSeason = _huntingSeasonService.RemoveAsync(new HuntingSeasonDTO() { Id = id }).Result;

                return RedirectToAction("Info", "Animal", new { Id = animalId });
            }
            catch { return BadRequest(); }

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
