namespace DAL.Intefaces
{
    public interface IGetByNameRepository<T>
    {
        public Task<T?> GetByName(string name);
    }
}
