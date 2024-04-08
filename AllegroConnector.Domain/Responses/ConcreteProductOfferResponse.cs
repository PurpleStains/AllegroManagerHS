using AllegroConnector.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllegroConnector.Domain.Responses
{
    public class ConcreteProductOfferResponse
    {
        public string name { get; set; }
        public List<ProductSet> productSet { get; set; }
        public List<Parameter> parameters { get; set; }
        public List<string> images { get; set; }
        public AfterSalesServices afterSalesServices { get; set; }
        public Payments payments { get; set; }
        public SellingMode sellingMode { get; set; }
        public Stock stock { get; set; }
        public Location location { get; set; }
        public Delivery delivery { get; set; }
        public Description description { get; set; }
        public External external { get; set; }
        public Category category { get; set; }
        public Tax tax { get; set; }
        public TaxSettings taxSettings { get; set; }
        public object sizeTable { get; set; }
        public Discounts discounts { get; set; }
        public object contact { get; set; }
        public object fundraisingCampaign { get; set; }
        public object messageToSellerSettings { get; set; }
        public List<object> attachments { get; set; }
        public object b2b { get; set; }
        public object additionalServices { get; set; }
        public object compatibilityList { get; set; }
        public AdditionalMarketplaces additionalMarketplaces { get; set; }
        public string id { get; set; }
        public string language { get; set; }
        public Publication publication { get; set; }
        public Validation validation { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }

    public class AdditionalMarketplaces
    {
        //[JsonProperty("allegro-cz")]
        public AllegroCz allegrocz { get; set; }

        //[JsonProperty("allegro-sk")]
        public AllegroSk allegrosk { get; set; }
    }

    public class AfterSalesServices
    {
        public ImpliedWarranty impliedWarranty { get; set; }
        public ReturnPolicy returnPolicy { get; set; }
        public Warranty warranty { get; set; }
    }

    public class AllegroCz
    {
        public object sellingMode { get; set; }
        public Publication publication { get; set; }
    }

    public class AllegroSk
    {
        public object sellingMode { get; set; }
        public Publication publication { get; set; }
    }

    public class Base
    {
        public string id { get; set; }
    }

    public class Category
    {
        public string id { get; set; }
    }

    public class Delivery
    {
        public ShippingRates shippingRates { get; set; }
        public string handlingTime { get; set; }
        public object additionalInfo { get; set; }
        public object shipmentDate { get; set; }
    }

    public class Description
    {
        public List<Section> sections { get; set; }
    }

    public class Discounts
    {
        public object wholesalePriceList { get; set; }
    }

    public class External
    {
        public string id { get; set; }
    }

    public class ImpliedWarranty
    {
        public string id { get; set; }
    }

    public class Item
    {
        public string type { get; set; }
        public string content { get; set; }
        public string url { get; set; }
    }

    public class Location
    {
        public string countryCode { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string postCode { get; set; }
    }

    public class Marketplaces
    {
        public Base @base { get; set; }
        public List<object> additional { get; set; }
    }

    //public class Parameter
    //{
    //    public string id { get; set; }
    //    public string name { get; set; }
    //    public List<string> values { get; set; }
    //    public List<string> valuesIds { get; set; }
    //    public object rangeValue { get; set; }
    //}

    public class Payments
    {
        public string invoice { get; set; }
    }

    public class Price
    {
        public string amount { get; set; }
        public string currency { get; set; }
    }

    public class Product
    {
        public string id { get; set; }
        public Publication publication { get; set; }
        [NotMapped]
        public List<Parameter> parameters { get; set; }
    }

    public class ProductSet
    {
        public Product product { get; set; }
        public Quantity quantity { get; set; }
        public object responsiblePerson { get; set; }
    }

    //public class Publication
    //{
    //    public string status { get; set; }
    //    public string state { get; set; }
    //    public List<object> refusalReasons { get; set; }
    //    public object duration { get; set; }
    //    public object endedBy { get; set; }
    //    public object endingAt { get; set; }
    //    public object startingAt { get; set; }
    //    public bool republish { get; set; }
    //    public Marketplaces marketplaces { get; set; }
    //}

    public class Quantity
    {
        public int value { get; set; }
    }

    public class ReturnPolicy
    {
        public string id { get; set; }
    }

    public class Section
    {
        public List<Item> items { get; set; }
    }

    //public class SellingMode
    //{
    //    public string format { get; set; }
    //    public Price price { get; set; }
    //    public object startingPrice { get; set; }
    //    public object minimalPrice { get; set; }
    //}

    public class ShippingRates
    {
        public string id { get; set; }
    }

    public class Stock
    {
        public int available { get; set; }
        public string unit { get; set; }
    }

    public class Tax
    {
        public object percentage { get; set; }
        public object rate { get; set; }
        public string subject { get; set; }
        public object exemption { get; set; }
        public string id { get; set; }
    }

    public class TaxSettings
    {
        public string subject { get; set; }
        public object exemption { get; set; }
        public List<object> rates { get; set; }
    }

    public class Validation
    {
        public List<object> errors { get; set; }
        public List<object> warnings { get; set; }
        public DateTime validatedAt { get; set; }
    }

    public class Warranty
    {
        public string id { get; set; }
    }

}
