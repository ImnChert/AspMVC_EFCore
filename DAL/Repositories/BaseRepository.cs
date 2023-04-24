using DAL.Entities;
using DAL.Intefaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public abstract class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected DbContext _dbContext;

        public BaseRepository(DbContext context)
        {
            _dbContext = context;
        }

        public void Create(TEntity entity)
            => _dbContext.Add(entity);

        public void Update(TEntity entity)
            => _dbContext.Update(entity);

        public void Remove(TEntity entity)
            => _dbContext.Remove(entity);

        public async Task Save()
            => await _dbContext.SaveChangesAsync();

        public abstract Task<TEntity> GetById(int id);

        public abstract IEnumerable<TEntity> GetAll();

        public abstract IEnumerable<TEntity> GetByPredicate(Func<TEntity, bool> predicate);
    }
}
