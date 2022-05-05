namespace CslAppSeries.Models
{
    public class Series
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public bool Deleted { get; set; } = false;
    }
}
