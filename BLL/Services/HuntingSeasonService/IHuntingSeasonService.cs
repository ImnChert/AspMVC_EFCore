using BLL.DTOs;
using BLL.Interfaces;

namespace BLL.Services.HuntingSeasonService
{
    internal interface IHuntingSeasonService : IRepositoryService<HuntingSeasonDTO>
    {
        public IEnumerable<HuntingSeasonDTO> GetIncludeInfo();
        public HuntingSeasonDTO GetByIdIncludeInfo(int id);
    }
}
