namespace BLL.DTOs
{
    public class AnimalDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int InformationAnimalId { get; set; }
        public InformationAnimalDTO? InformationAnimal { get; set; }
        public List<HuntingSeasonDTO> HuntingSeasons { get; set; } = new List<HuntingSeasonDTO>();
    }
}
