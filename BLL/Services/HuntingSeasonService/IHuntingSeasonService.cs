using BLL.DTOs;
using BLL.Interfaces;

namespace BLL.Services.HuntingSeasonService
{
    public interface IHuntingSeasonService : IBaseService<HuntingSeasonDTO, HuntingSeasonDTO>
    {
        public Task<List<HuntingSeasonDTO>> GetByAnimalId(int animalId);
    }
}
