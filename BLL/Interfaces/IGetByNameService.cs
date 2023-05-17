namespace BLL.Interfaces
{
    public interface IGetByNameService<T>
    {
        public Task<T> GetByNameAsync();
    }
}
