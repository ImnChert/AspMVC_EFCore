using AutoMapper;
using BLL.DTOs;
using BLL.Services.AnimalService;
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

        public IActionResult Update()
        {
            return View();
        }

        public IActionResult Create(int id)
        {
            return View(new HuntingSeasonViewModel() { AnimalId = id });
        }

        [HttpPut]
        public IActionResult Update(string name)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Create(HuntingSeasonViewModel huntingSeason)
        {
            try
            {
                var huntingSeasonDto = _mapper.Map<HuntingSeasonDTO>(huntingSeason);
                _huntingSeasonService.CreateAsync(huntingSeasonDto);

                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var huntingSeason = _huntingSeasonService.RemoveAsync(new HuntingSeasonDTO() { Id = id });

                return Ok(huntingSeason);
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
