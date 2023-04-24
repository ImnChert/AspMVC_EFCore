namespace DAL.Intefaces
{
    public interface IRepository<TEntity>
    {
        public void Create(TEntity item);
        public Task<TEntity?> GetByIdAsync(int id);
        public Task<IEnumerable<TEntity>> GetAllAsync();
        public Task<IEnumerable<TEntity>> GetByPredicateAsync(Func<TEntity, bool> predicate);
        public void Remove(TEntity entity);
        public void Update(TEntity item);
        public Task SaveAsync();
    }
}
