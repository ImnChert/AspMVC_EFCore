namespace BLL.DTOs
{
    public class HuntingSeasonDTO
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int InformationHuntingSeasonId { get; set; }
        public InformationHuntingSeasonDTO? InformationHuntingSeason { get; set; }
        public List<AnimalDTO> Animals { get; set; } = new List<AnimalDTO>();
    }
}
