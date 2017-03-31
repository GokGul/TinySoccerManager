namespace TinySoccerManager.Models
{
    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public virtual Player Player { get; set; }
    }
}