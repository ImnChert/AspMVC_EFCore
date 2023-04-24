namespace BLL.Interfaces
{
    public interface IBaseService<T> where T : class
    {
        public Task<T> GetById(int id);
        public Task<List<T>> GetAll();
        public Task<T> Create(T item);
        public Task<T> Remove(T item);
        public Task<T> Update(T item);
    }
}
