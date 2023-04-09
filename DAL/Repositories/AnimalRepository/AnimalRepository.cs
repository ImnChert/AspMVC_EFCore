using DAL.Configurations;
using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.AnimalRepository
{
    internal class AnimalRepository : Repository<Animal>, IAnimalRepository
    {
        public AnimalRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
