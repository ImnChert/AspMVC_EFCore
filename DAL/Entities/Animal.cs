using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class Animal
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string ImageUrl { get; set; } = string.Empty;
        public int InformationAnimalId { get; set; }
        public InformationAnimal? InformationAnimal { get; set; }
        public List<HuntingSeason> HuntingSeasons { get; set; } = new();
    }
}
