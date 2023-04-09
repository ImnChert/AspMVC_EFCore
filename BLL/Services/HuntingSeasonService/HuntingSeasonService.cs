using AutoMapper;
using BLL.DTOs;
using DAL.Entities;
using DAL.Repositories.AnimalRepository;
using DAL.Repositories.HuntingSeasonRepository;

namespace BLL.Services.HuntingSeasonService
{
    internal class HuntingSeasonService : IHuntingSeasonService
    {
        private IHuntingSeasonRepository _repository;
        private IMapper _mapper;

        public HuntingSeasonService(IHuntingSeasonRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<HuntingSeasonDTO> Create(HuntingSeasonDTO item)
        {
            if(item is null)
                throw new Exception("Value is null");

            var data = _mapper.Map<HuntingSeason>(item);
            await _repository.Create(data);

            return item;
        }

        public IEnumerable<HuntingSeasonDTO> Get()
        {
            IEnumerable<HuntingSeason> items = _repository.Get();

            if(items is null)
                throw new Exception("Value is null");

            var data = _mapper.Map<IEnumerable<HuntingSeasonDTO>>(items);

            return data;
        }

        public IEnumerable<HuntingSeasonDTO> Get(Func<HuntingSeasonDTO, bool> predicate)
        {
            var predict = _mapper.Map<Func<HuntingSeason, bool>>(predicate);

            IEnumerable<HuntingSeason> items = _repository.Get(predict);

            if(items is null)
                throw new Exception("Value is null");

            var data = _mapper.Map<IEnumerable<HuntingSeasonDTO>>(items);

            return data;
        }

        public async Task<HuntingSeasonDTO> GetById(int id)
        {
            HuntingSeason item = await _repository.GetById(id);

            if(item is null)
                throw new Exception("Value is null");

            var data = _mapper.Map<HuntingSeasonDTO>(item);

            return data;
        }

        public HuntingSeasonDTO GetByIdIncludeInfo(int id)
        {
            HuntingSeason item = _repository.GetWithInclude(e => e.Id == id, a => a.InformationHuntingSeason).ToList()[0];

            if(item is null)
                throw new Exception("Value is null");

            var data = _mapper.Map<HuntingSeasonDTO>(item);

            return data;
        }

        public IEnumerable<HuntingSeasonDTO> GetIncludeInfo()
        {
            IEnumerable<HuntingSeason> item = _repository.GetWithInclude(a => a.InformationHuntingSeason);

            if(item is null)
                throw new Exception("Value is null");

            var data = _mapper.Map<IEnumerable<HuntingSeasonDTO>>(item);

            return data;
        }

        public async Task<HuntingSeasonDTO> Remove(int id)
        {
            await _repository.Remove(id);

            // var data = _mapper.Map<HuntingSeasonDTO>(item);

            return new HuntingSeasonDTO() { Id = id };
        }

        public async Task<HuntingSeasonDTO> Update(HuntingSeasonDTO item)
        {
            var data = _mapper.Map<HuntingSeason>(item);
            await _repository.Update(data);

            return item;
        }
    }
}
