using System.ComponentModel.DataAnnotations;

namespace DAL.Entities
{
    public class HuntingSeason : BaseEntity
    {
        [Required]
        public DateTime DateStart { get; set; }
        [Required]
        public DateTime DateEnd { get; set; }
        public int InformationHuntingSeasonId { get; set; }
        public InformationHuntingSeason? InformationHuntingSeason { get; set; }
        public int AnimalId { get; set; }
        public Animal? Animal { get; set; }
    }
}
