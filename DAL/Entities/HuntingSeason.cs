namespace DAL.Entities
{
    public class HuntingSeason : BaseEntity
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public int InformationHuntingSeasonId { get; set; }
        public InformationHuntingSeason? InformationHuntingSeason { get; set; }
        public List<Animal> Animals { get; set; } = new List<Animal>();
    }
}
