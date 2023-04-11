using BLL.DTOs;
using BLL.Interfaces;

namespace BLL.Services.AnimalService
{
    public interface IAnimalService : IRepositoryService<AnimalDTO>
    {
        public IEnumerable<AnimalDTO> GetIncludeInfo();
        public AnimalDTO GetByIdIncludeInfo(int id);
    }
}
