namespace AllegroConnector.Domain.Models
{
    public class Parameter
    {
        public string id { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public List<string> values { get; set; }
        public List<string> valuesIds { get; set; }
    }
}
