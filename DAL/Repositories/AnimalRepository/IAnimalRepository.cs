using DAL.Entities;
using DAL.Intefaces;

namespace DAL.Repositories.AnimalRepository
{
    public interface IAnimalRepository : IRepository<Animal>, IEagerRepository<Animal>
    {
    }
}
