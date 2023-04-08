using DAL.Entities;
using DAL.Intefaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DAL.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity>, IEagerRepository<TEntity> where TEntity : BaseEntity
    {
        DbContext _dbContext;
        DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> Get()
            => _dbSet.AsNoTracking();

        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
            => _dbSet.AsNoTracking()
            .Where(predicate);

        public async Task<TEntity> GetById(int id)
            => await _dbSet.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == id);

        public async Task Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Remove(int id)
        {
            var entity = await GetById(id);
            _dbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public IEnumerable<TEntity> GetWithInclude(params Expression<Func<TEntity, object>>[] includeProperties)
            => Include(includeProperties);

        public IEnumerable<TEntity> GetWithInclude(Func<TEntity, bool> predicate,
            params Expression<Func<TEntity, object>>[] includeProperties)
        {
            var query = Include(includeProperties);

            return query.Where(predicate);
        }

        private IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();

            return includeProperties
                .Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
    }
}
