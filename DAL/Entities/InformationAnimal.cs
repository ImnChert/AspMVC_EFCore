using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class InformationAnimal
    {
        public int Id { get; set; }
        [Required]
        public string Description { get; set; } = string.Empty;
    }
}
