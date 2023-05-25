using BLL.DTOs;
using BLL.Services.AnimalService;
using Microsoft.AspNetCore.Mvc;

namespace AspWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private IAnimalService _animalService;
        private ILogger<AnimalController> _logger;

        public AnimalController(IAnimalService animalService, ILogger<AnimalController> logger)
        {
            _animalService = animalService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimalDTO>>> GetAll()
        {
            var animals = await _animalService.GetAllAsync();

            return Ok(animals);
        }

        [HttpGet("id:int")]
        public async Task<ActionResult<AnimalDetailDTO>> GetById([FromHeader] int id)
        {
            var animal = await _animalService.GetByIdAsync(id);

            return Ok(animal);
        }

        [HttpPost]
        public async Task<ActionResult<AnimalDetailDTO>> Create([FromBody] AnimalDetailDTO animal)
        {
            var result = await _animalService.CreateAsync(animal);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<AnimalDetailDTO>> Update([FromBody] AnimalDetailDTO animal)
        {
            var result = await _animalService.UpdateAsync(animal);

            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<AnimalDetailDTO>> Remove([FromBody] AnimalDetailDTO animal)
        {
            var result = await _animalService.RemoveAsync(animal);

            return Ok(result);
        }

        [HttpDelete("name:string")]
        public async Task<ActionResult<AnimalDetailDTO>> RemoveByName([FromHeader] string name)
        {
            var result = await _animalService.RemoveAsync(new AnimalDetailDTO { Name = name });

            return Ok(result);
        }
    }
}
