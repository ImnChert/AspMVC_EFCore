namespace HunterWeb.ViewModels
{
    public class HuntingSeasonViewModel
    {
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public InfoHuntingSeasonViewModel? InformationHuntingSeason { get; set; }
    }
}
