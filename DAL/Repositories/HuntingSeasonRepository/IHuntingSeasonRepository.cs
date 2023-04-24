using DAL.Entities;
using DAL.Intefaces;

namespace DAL.Repositories.HuntingSeasonRepository
{
    public interface IHuntingSeasonRepository : IRepository<HuntingSeason>, IEagerRepository<HuntingSeason>
    {
    }
}
