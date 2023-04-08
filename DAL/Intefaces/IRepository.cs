namespace DAL.Intefaces
{
    public interface IRepository<TEntity>
    {
        public Task Create(TEntity item);
        public Task<TEntity> GetById(int id);
        public IEnumerable<TEntity> Get();
        public IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        public Task Remove(int id);
        public Task Update(TEntity item);
    }
}
