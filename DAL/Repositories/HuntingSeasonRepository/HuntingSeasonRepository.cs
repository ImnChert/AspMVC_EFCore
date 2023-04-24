using DAL.Configurations;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.HuntingSeasonRepository
{
    internal class HuntingSeasonRepository : BaseRepository<HuntingSeason>, IHuntingSeasonRepository
    {
        public HuntingSeasonRepository(ApplicationContext context) : base(context)
        {
        }

        public async override Task<IEnumerable<HuntingSeason>> GetAllAsync()
             => await _dbContext.HuntingSeasons
            .AsNoTracking()
            .ToListAsync();

        public async Task<IEnumerable<HuntingSeason>> GetAllWithIncludeAsync()
            => await _dbContext.HuntingSeasons
            .Include(h => h.InformationHuntingSeason)
            .AsNoTracking()
            .ToListAsync();

        public async override Task<HuntingSeason?> GetByIdAsync(int id)
            => await _dbContext.HuntingSeasons
            .AsNoTracking()
            .FirstOrDefaultAsync(h => h.Id == id);

        public async Task<HuntingSeason?> GetByIdWithIncludeAsync(int id)
            => await _dbContext.HuntingSeasons
            .Include(h => h.InformationHuntingSeason)
            .AsNoTracking()
            .FirstOrDefaultAsync(h => h.Id == id);

        public async override Task<IEnumerable<HuntingSeason>> GetByPredicateAsync(Func<HuntingSeason, bool> predicate)
            => await _dbContext.HuntingSeasons
            .Include(h => h.InformationHuntingSeason)
            .AsNoTracking()
            .Where(o => predicate(o))
            .ToListAsync();
    }
}
