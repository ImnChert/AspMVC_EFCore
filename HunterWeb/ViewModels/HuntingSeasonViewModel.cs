namespace HunterWeb.ViewModels
{
    public class HuntingSeasonViewModel
    {
        public int Id { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public InfoHuntingSeasonViewModel? InformationHuntingSeason { get; set; }
    }
}
