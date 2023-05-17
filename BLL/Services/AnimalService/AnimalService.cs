using AutoMapper;
using BLL.DTOs;
using BLL.Services.HuntingSeasonService;
using DAL.Entities;
using DAL.Repositories.AnimalRepository;
using DAL.Repositories.HuntingSeasonRepository;
using Microsoft.Extensions.Logging;

namespace BLL.Services.AnimalService
{
    internal class AnimalService : IAnimalService
    {
        private IAnimalRepository _animalRepository;
        private IHuntingSeasonRepository _huntingSeasonRepository;
        private IMapper _mapper;
        private ILogger<IHuntingSeasonService> _logger;

        public AnimalService(IAnimalRepository animalRepository, IHuntingSeasonRepository huntingSeasonRepository,
            IMapper mapper, ILogger<IHuntingSeasonService> logger)
        {
            _animalRepository = animalRepository;
            _huntingSeasonRepository = huntingSeasonRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<AnimalDetailDTO> CreateAsync(AnimalDetailDTO item)
        {
            var animalChecked = await _animalRepository.GetByNameAsync(item.Name);

            if(animalChecked is not null)
            {
                _logger.LogError("");

                throw new Exception("This name is already used");
            }

            var mapperModel = _mapper.Map<Animal>(item);

            _animalRepository.Create(mapperModel);

            await _animalRepository.SaveAsync();

            return item;
        }

        public async Task<List<AnimalDTO>> GetAllAsync()
        {
            var animalsChecked = await _animalRepository.GetAllAsync();

            if(animalsChecked is null)
            {
                _logger.LogError("");

                throw new Exception("There is not data yet");
            }

            var mapperModel = _mapper.Map<List<AnimalDTO>>(animalsChecked);

            return mapperModel;
        }

        public async Task<AnimalDetailDTO> GetByIdAsync(int id)
        {
            var animalChecked = await _animalRepository.GetByIdWithIncludeAsync(id);

            if(animalChecked is null)
            {
                _logger.LogError("");

                throw new Exception("There is not data yet");
            }

            var mapperModel = _mapper.Map<AnimalDetailDTO>(animalChecked);

            return mapperModel;
        }

        public async Task<AnimalDetailDTO> RemoveAsync(AnimalDetailDTO item)
        {
            var animalChecked = await _animalRepository.GetByNameAsync(item.Name);

            if(animalChecked is null)
            {
                _logger.LogError("");

                throw new Exception("This name is already used");
            }

            _animalRepository.Remove(animalChecked);

            await _animalRepository.SaveAsync();

            return item;
        }

        public async Task<AnimalDetailDTO> UpdateAsync(AnimalDetailDTO item)
        {
            var animalChecked = await _animalRepository.GetByIdWithIncludeAsync(item.Id);

            if(animalChecked is null)
            {
                _logger.LogError("");

                throw new Exception("This name is already used");
            }

            animalChecked.Name = item.Name;
            animalChecked.InformationAnimal!.Description = item.Description;

            _animalRepository.Update(animalChecked);

            await _animalRepository.SaveAsync();

            return item;
        }
    }
}
