using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AllegroConnector.Domain.Models
{
    public class StartingPrice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string amount { get; set; }
        public string currency { get; set; }
    }
}
