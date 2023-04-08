namespace BLL.Interfaces
{
    internal interface IRepositoryService<T> where T : class
    {
        public Task<T> Create(T item);
        public Task<T> GetById(int id);
        public IEnumerable<T> Get();
        public IEnumerable<T> Get(Func<T, bool> predicate);
        public Task<T> Remove(int id);
        public Task<T> Update(T item);
    }
}
