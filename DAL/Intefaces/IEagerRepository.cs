using System.Linq.Expressions;

namespace DAL.Intefaces
{
    public interface IEagerRepository<TEntity>
    {
        public Task<IEnumerable<TEntity>> GetAllWithInclude();

        public Task<IEnumerable<TEntity>> GetByIdWithInclude(int id);
    }
}
