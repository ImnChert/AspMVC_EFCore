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
            var animalsDto = _animalService.GetAllAsync().Result;

            _animals = _mapper.Map<List<ShortAnimalViewModel>>(animalsDto);

            return View(_animals);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Info(int id)
        {
            AnimalDetailDTO animalDto = _animalService.GetByIdAsync(id).Result;

            animalDto.HuntingSeasons = _huntingSeasonService.GetByAnimalId(animalDto.Id).Result;

            var animal = _mapper.Map<AnimalViewModel>(animalDto);

            return View(animal);
        }

        [HttpPost]
        public IActionResult CreateAnimal(AnimalViewModel animal, IFormFile uploadedFile)
        {
            try
            {
                animal.ImageUrl = "images/" + uploadedFile.FileName;
                var animalDto = _mapper.Map<AnimalDetailDTO>(animal);
                var s = _animalService.CreateAsync(animalDto).Result;

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        public IActionResult Remove(int id)
        {
            try
            {
                _animalService.RemoveAsync(new AnimalDetailDTO { Id = id });

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return RedirectToAction("Index");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
