using DAL.Configurations;
using DAL.Entities;
using DAL.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected ApplicationContext _dbContext;

        public BaseRepository(ApplicationContext context)
        {
            _dbContext = context;
        }

        public void Create(TEntity entity)
            => _dbContext.Add(entity);

        public void Update(TEntity entity)
            => _dbContext.Update(entity);

        public void Remove(TEntity entity)
            => _dbContext.Remove(entity);

        public async Task SaveAsync()
            => await _dbContext.SaveChangesAsync();

        public abstract Task<TEntity?> GetByIdAsync(int id);

        public abstract Task<IEnumerable<TEntity>> GetAllAsync();

        public abstract Task<IEnumerable<TEntity>> GetByPredicateAsync(Func<TEntity, bool> predicate);
    }
}
