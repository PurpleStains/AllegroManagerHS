using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AllegroConnector.Domain.Models
{
    public class Promotion
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public bool emphasized1d { get; set; } = false;
        public bool emphasized10d { get; set; } = false;
        public bool promoPackage { get; set; } = false;
        public bool departmentPage { get; set; } = false; 
    }
}
