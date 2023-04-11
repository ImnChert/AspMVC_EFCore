using BLL.DTOs;

namespace HunterWeb.ViewModels
{
    public class AnimalViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public InfoAnimalViewModel InformationAnimal { get; set; } = new InfoAnimalViewModel();
        public List<HuntingSeasonViewModel> HuntingSeasons { get; set; } = new List<HuntingSeasonViewModel>();
    }
}
