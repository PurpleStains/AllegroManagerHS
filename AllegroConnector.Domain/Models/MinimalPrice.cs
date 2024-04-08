using System.ComponentModel.DataAnnotations;

namespace AllegroConnector.Domain.Models
{
    public class MinimalPrice
    {
        [Key]
        public Guid Id { get; set; }
        public string amount { get; set; }
        public string currency { get; set; }
    }
}
