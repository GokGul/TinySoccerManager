using System.ComponentModel.DataAnnotations;

namespace TinySoccerManager.Models
{
    public class GameResult
    {
        public int Id { get; set; }
        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }
        [Display(Name = "Aantal doelpunten")]
        public int? Goals { get; set; }
        [Display(Name = "Aantal aanvallen gestopt")]
        public int? OffenceStopped { get; set; }
        public int? Yellow { get; set; }
        public int? Red { get; set; }
    }
}