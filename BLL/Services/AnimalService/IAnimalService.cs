using BLL.DTOs;
using BLL.Interfaces;

namespace BLL.Services.AnimalService
{
    internal interface IAnimalService : IRepositoryService<AnimalDTO>
    {
        public IEnumerable<AnimalDTO> GetIncludeInfo();
        public AnimalDTO GetByIdIncludeInfo(int id);
    }
}
