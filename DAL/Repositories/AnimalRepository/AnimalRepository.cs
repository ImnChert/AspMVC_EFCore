using DAL.Configurations;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.AnimalRepository
{
    internal class AnimalRepository : BaseRepository<Animal>, IAnimalRepository
    {
        public AnimalRepository(ApplicationContext context) : base(context)
        {
        }

        public async override Task<IEnumerable<Animal>> GetAllAsync()
            => await _dbContext.Animals
            .AsNoTracking()
            .ToListAsync();

        public async Task<IEnumerable<Animal>> GetAllWithIncludeAsync()
             => await _dbContext.Animals
            .Include(a => a.InformationAnimal)
            .AsNoTracking()
            .ToListAsync();

        public async override Task<Animal?> GetByIdAsync(int id)
            => await _dbContext.Animals
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);

        public async Task<Animal?> GetByIdWithIncludeAsync(int id)
          => await _dbContext.Animals
            .Include(a => a.InformationAnimal)
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Id == id);

        public async Task<Animal?> GetByNameAsync(string name)
            => await _dbContext.Animals
            .AsNoTracking()
            .FirstOrDefaultAsync(a => a.Name == name);

        public async override Task<IEnumerable<Animal>> GetByPredicateAsync(Func<Animal, bool> predicate)
            => await _dbContext.Animals
            .Include(a => a.InformationAnimal)
            .AsNoTracking()
            .Where(o => predicate(o))
            .ToListAsync();
    }
}
