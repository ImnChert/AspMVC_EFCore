using AutoMapper;
using BLL.DTOs;
using DAL.Entities;
using DAL.Repositories.AnimalRepository;
using DAL.Repositories.HuntingSeasonRepository;
using Microsoft.Extensions.Logging;

namespace BLL.Services.HuntingSeasonService
{
    internal class HuntingSeasonService : IHuntingSeasonService
    {
        private IHuntingSeasonRepository _huntingSeasonRepository;
        private IMapper _mapper;
        private ILogger<HuntingSeasonService> _logger;

        public HuntingSeasonService(IHuntingSeasonRepository huntingSeasonRepository, IMapper mapper, ILogger<HuntingSeasonService> logger)
        {
            _huntingSeasonRepository = huntingSeasonRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<HuntingSeasonDTO> CreateAsync(HuntingSeasonDTO item)
        {
            // TODO: под вопросам
            var huntingSeasonChecked = await _huntingSeasonRepository.GetByIdAsync(item.Id);

            if(huntingSeasonChecked is not null)
            {
                _logger.LogError("");

                throw new Exception("This name is already used");
            }

            var mapperModel = _mapper.Map<HuntingSeason>(item);
            //mapperModel.InformationHuntingSeasonId = 1;
            _huntingSeasonRepository.Create(mapperModel);

            await _huntingSeasonRepository.SaveAsync();

            return item;
        }

        public async Task<List<HuntingSeasonDTO>> GetAllAsync()
        {
            var huntingSeasonChecked = await _huntingSeasonRepository.GetAllAsync();

            if(huntingSeasonChecked is null)
            {
                _logger.LogError("");

                throw new Exception("There is not data yet");
            }

            var mapperModel = _mapper.Map<List<HuntingSeasonDTO>>(huntingSeasonChecked);

            return mapperModel;
        }

        public async Task<List<HuntingSeasonDTO>> GetByAnimalId(int animalId)
        {
            var huntingSeasonChecked = (await _huntingSeasonRepository.GetAllWithIncludeAsync()).Where(x => x.AnimalId == animalId);

            if(huntingSeasonChecked is null)
            {
                _logger.LogError("");

                throw new Exception("There is not data yet");
            }

            var mapperModel = _mapper.Map<List<HuntingSeasonDTO>>(huntingSeasonChecked.ToList());

            return mapperModel;
        }

        public async Task<HuntingSeasonDTO> GetByIdAsync(int id)
        {
            var huntingSeasonChecked = await _huntingSeasonRepository.GetByIdWithIncludeAsync(id);

            if(huntingSeasonChecked is null)
            {
                _logger.LogError("");

                throw new Exception("There is not data yet");
            }

            var mapperModel = _mapper.Map<HuntingSeasonDTO>(huntingSeasonChecked);

            return mapperModel;
        }

        public async Task<HuntingSeasonDTO> RemoveAsync(HuntingSeasonDTO item)
        {
            var huntingSeasonChecked = await _huntingSeasonRepository.GetByIdAsync(item.Id);

            if(huntingSeasonChecked is null)
            {
                _logger.LogError("");

                throw new Exception("This name is already used");
            }

            var mapperModel = _mapper.Map<HuntingSeason>(item);

            _huntingSeasonRepository.Remove(mapperModel);

            await _huntingSeasonRepository.SaveAsync();

            return item;
        }

        public async Task<HuntingSeasonDTO> UpdateAsync(HuntingSeasonDTO item)
        {
            var huntingSeasonChecked = await _huntingSeasonRepository.GetByIdAsync(item.Id);

            if(huntingSeasonChecked is null)
            {
                _logger.LogError("");

                throw new Exception("This name is already used");
            }

            var mapperModel = _mapper.Map<HuntingSeason>(item);

            _huntingSeasonRepository.Update(mapperModel);

            await _huntingSeasonRepository.SaveAsync();

            return item;
        }
    }
}
