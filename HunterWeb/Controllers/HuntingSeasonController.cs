using AutoMapper;
using BLL.Services.AnimalService;
using BLL.Services.HuntingSeasonService;
using HunterWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;

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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPut]
        public IActionResult Update(string name)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Create(string name)
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                var huntingSeason = _huntingSeasonService.Remove(id);

                return Ok(huntingSeason);
            }
            catch { return BadRequest(); }

        }
    }
}
