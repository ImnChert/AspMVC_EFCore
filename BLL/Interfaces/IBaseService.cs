namespace BLL.Interfaces
{
    public interface IBaseService<T, TDetail> where T : class
    {
        public Task<TDetail> GetByIdAsync(int id);
        public Task<List<T>> GetAllAsync();
        public Task<TDetail> CreateAsync(TDetail item);
        public Task<TDetail> RemoveAsync(TDetail item);
        public Task<TDetail> UpdateAsync(TDetail item);
    }
}
