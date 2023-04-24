using AutoMapper;
using BLL.DTOs;
using BLL.Services.AnimalService;
using BLL.Services.HuntingSeasonService;
using HunterWeb.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HunterWeb.Controllers
{
    public class AnimalController : Controller
    {
        private readonly IAnimalService _animalService;
        private readonly IHuntingSeasonService _huntingSeasonService;
        private readonly IMapper _mapper;
        private List<ShortAnimalViewModel> _animals = new List<ShortAnimalViewModel>();
        private readonly ILogger<AnimalController> _logger;

        public AnimalController(IAnimalService animalService, IHuntingSeasonService huntingSeasonService, IMapper mapper, ILogger<AnimalController> logger)
        {
            _animalService = animalService;
            _huntingSeasonService = huntingSeasonService;
            _mapper = mapper;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var animalsDto = _animalService.Get().ToList();

            _animals = _mapper.Map<List<ShortAnimalViewModel>>(animalsDto);

            return View(_animals);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Info(int id)
        {
            AnimalDTO animalDto = _animalService.GetByIdIncludeInfo(id);
            List<HuntingSeasonDTO> huntingsSeasons = _huntingSeasonService.GetIncludeInfo()
                .Where(h => h.AnimalId == animalDto.Id)
                .ToList();
            animalDto.HuntingSeasons = huntingsSeasons;

            var animal = _mapper.Map<AnimalViewModel>(animalDto);

            return View(animal);
        }

        [HttpPost]
        public IActionResult Create(string name, IFormFile avatar, string additionalName, string description)
        {
            try
            {
                //animal.ImageUrl = animal.Avatar.FileName;
                //var animalDto = _mapper.Map<AnimalDTO>(animal);
                //_animalService.Create(animalDto);

                return RedirectToAction("Index");
            }
            catch
            {
                return BadRequest();
            }
        }


    }
}
