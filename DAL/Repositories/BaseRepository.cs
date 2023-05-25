using DAL.Configurations;
using DAL.Intefaces;

namespace DAL.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity>
    {
        protected ApplicationContext _dbContext;

        public BaseRepository(ApplicationContext context)
        {
            _dbContext = context;
        }

        public void Create(TEntity entity)
            => _dbContext.Add(entity!);

        public void Update(TEntity entity)
            => _dbContext.Update(entity!);

        public void Remove(TEntity entity)
            => _dbContext.Remove(entity!);

        public async Task SaveAsync()
            => await _dbContext.SaveChangesAsync();

        public abstract Task<TEntity?> GetByIdAsync(int id);

        public abstract Task<IEnumerable<TEntity>> GetAllAsync();

        public abstract Task<IEnumerable<TEntity>> GetByPredicateAsync(Func<TEntity, bool> predicate);
    }
}
