using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class InformationAnimal : BaseEntity
    {
        public string AddtionalName { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
