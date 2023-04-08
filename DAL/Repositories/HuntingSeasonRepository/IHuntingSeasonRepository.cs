using DAL.Entities;
using DAL.Intefaces;

namespace DAL.Repositories.HuntingSeasonRepository
{
    internal interface IHuntingSeasonRepository : IRepository<HuntingSeason>, IEagerRepository<HuntingSeason>
    {
    }
}
