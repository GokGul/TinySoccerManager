namespace TinySoccerManager.Models
{
    public class GameResult
    {
        public int Id { get; set; }
        public virtual Game Game { get; set; }
        public virtual Player Player { get; set; }
        public int Goals { get; set; }
        public int Yellow { get; set; }
        public int Red { get; set; }
    }
}