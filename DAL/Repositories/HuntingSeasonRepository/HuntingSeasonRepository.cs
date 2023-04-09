using DAL.Configurations;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.HuntingSeasonRepository
{
    internal class HuntingSeasonRepository : Repository<HuntingSeason>, IHuntingSeasonRepository
    {
        public HuntingSeasonRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
