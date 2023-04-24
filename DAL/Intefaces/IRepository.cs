namespace DAL.Intefaces
{
    public interface IRepository<TEntity>
    {
        public void Create(TEntity item);
        public Task<TEntity> GetById(int id);
        public IEnumerable<TEntity> GetAll();
        public IEnumerable<TEntity> GetByPredicate(Func<TEntity, bool> predicate);
        public void Remove(TEntity entity);
        public void Update(TEntity item);
        public Task Save();
    }
}
