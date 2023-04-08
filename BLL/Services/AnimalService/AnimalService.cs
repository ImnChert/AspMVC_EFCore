using AutoMapper;
using BLL.DTOs;
using DAL.Entities;
using DAL.Repositories.AnimalRepository;

namespace BLL.Services.AnimalService
{
    internal class AnimalService : IAnimalService
    {
        private IAnimalRepository _animalRepository;
        private IMapper _mapper;

        public AnimalService(IAnimalRepository animalRepository, IMapper mapper)
        {
            _animalRepository = animalRepository;
            _mapper = mapper;
        }

        public async Task<AnimalDTO> Create(AnimalDTO item)
        {
            if(item is null)
                throw new Exception("Value is null");

            var data = _mapper.Map<Animal>(item);
            await _animalRepository.Create(data);

            return item;
        }

        public IEnumerable<AnimalDTO> Get()
        {
            IEnumerable<Animal> items = _animalRepository.Get();

            if(items is null)
                throw new Exception("Value is null");

            var data = _mapper.Map<IEnumerable<AnimalDTO>>(items);

            return data;
        }

        public IEnumerable<AnimalDTO> Get(Func<AnimalDTO, bool> predicate)
        {
            var predict = _mapper.Map<Func<Animal, bool>>(predicate);

            IEnumerable<Animal> items = _animalRepository.Get(predict);

            if(items is null)
                throw new Exception("Value is null");

            var data = _mapper.Map<IEnumerable<AnimalDTO>>(items);

            return data;
        }

        public async Task<AnimalDTO> GetById(int id)
        {
            Animal item = await _animalRepository.GetById(id);

            if(item is null)
                throw new Exception("Value is null");

            var data = _mapper.Map<AnimalDTO>(item);

            return data;
        }

        public AnimalDTO GetByIdIncludeInfo(int id)
        {
            Animal item = _animalRepository.GetWithInclude(e => e.Id == id, a => a.InformationAnimal).ToList()[0];

            if(item is null)
                throw new Exception("Value is null");

            var data = _mapper.Map<AnimalDTO>(item);

            return data;
        }

        public IEnumerable<AnimalDTO> GetIncludeInfo()
        {
            IEnumerable<Animal> item = _animalRepository.GetWithInclude(a => a.InformationAnimal);

            if(item is null)
                throw new Exception("Value is null");

            var data = _mapper.Map<IEnumerable<AnimalDTO>>(item);

            return data;
        }

        public async Task<AnimalDTO> Remove(int id)
        {
            await _animalRepository.Remove(id);

            // var data = _mapper.Map<AnimalDTO>(item);

            return new AnimalDTO() { Id = id };
        }

        public async Task<AnimalDTO> Update(AnimalDTO item)
        {
            var data = _mapper.Map<Animal>(item);
            await _animalRepository.Update(data);

            return item;
        }
    }
}
