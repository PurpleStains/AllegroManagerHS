using System.ComponentModel.DataAnnotations;

namespace AllegroConnector.Domain.Models
{
    public class CategoryOptions
    {
        [Key]
        public Guid Id { get; set; }
        public bool advertisement { get; set; }
        public bool advertisementPriceOptional { get; set; }
        public bool variantsByColorPatternAllowed { get; set; }
        public bool offersWithProductPublicationEnabled { get; set; }
        public bool productCreationEnabled { get; set; }
        public bool customParametersEnabled { get; set; }
        public bool sellerCanRequirePurchaseComments { get; set; }
    }
}
