using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AllegroConnector.Domain.Models
{
    public class Price
    {
        public string amount { get; set; }
        public string currency { get; set; }
    }
}
