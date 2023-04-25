namespace DAL.Intefaces
{
    public interface IGetByNameRepository<T>
    {
        public Task<T?> GetByNameAsync(string name);
    }
}
