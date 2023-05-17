namespace DAL.Intefaces
{
    public interface IEagerRepository<TEntity>
    {
        public Task<IEnumerable<TEntity>> GetAllWithIncludeAsync();

        public Task<TEntity?> GetByIdWithIncludeAsync(int id);
    }
}
