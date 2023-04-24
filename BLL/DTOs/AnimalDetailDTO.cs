namespace BLL.DTOs
{
    public class AnimalDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public int InformationAnimalId { get; set; }
        public string AddtionalName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public List<HuntingSeasonDTO> HuntingSeasons { get; set; } = new List<HuntingSeasonDTO>();
    }
}
