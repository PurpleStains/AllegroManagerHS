namespace AllegroConnector.Domain.Models
{
    public class Publication
    {
        public string status { get; set; }
        public string? startingAt { get; set; }
        public DateTime? startedAt { get; set; }
        public DateTime? endingAt { get; set; }
        public string? endedAt { get; set; }
    }

}
