using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories.AnimalRepository
{
    internal class AnimalRepository : Repository<Animal>, IAnimalRepository
    {
        public AnimalRepository(DbContext context) : base(context)
        {
        }
    }
}
