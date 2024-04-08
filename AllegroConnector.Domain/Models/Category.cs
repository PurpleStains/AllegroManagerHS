namespace AllegroConnector.Domain.Models
{
    public class CategoryFromResponse
    {
        public string id { get; set; }
        public bool leaf { get; set; }
        public string name { get; set; }
        public CategoryOptions options { get; set; }
        public CategoryParent parent { get; set; }
    }
}
