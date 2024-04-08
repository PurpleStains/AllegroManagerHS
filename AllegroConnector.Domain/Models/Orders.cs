using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AllegroConnector.Domain.Models
{
    public class CheckoutFormResponse
    {
        public CheckoutForm[] checkoutForms { get; set; }
        public int count { get; set; }
        public int totalCount { get; set; }
    }

    public class CheckoutForm
    {
        public Guid Id { get; set; }
        public string? MessageToSeller { get; set; }
        public virtual OrderBuyer Buyer { get; set; }
        public string Status { get; set; }
        public virtual ICollection<OrderLineItem> LineItems { get; set; }
        public virtual ICollection<OrderSurcharge> Surcharges { get; set; }
        public virtual ICollection<OrderDiscount> Discounts { get; set; }
        public string? Note { get; set; }
        public Marketplace Marketplace { get; set; }
        public Summary Summary { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
    public class Summary
    {
        public OrderSummary TotalToPay { get; set; }
    }
    public class OrderSurcharge
    {
        public Guid Id { get; set; }
        public string SurchargeId { get; set; }
        public string Type { get; set; }
        public string Provider { get; set; }
        public DateTime FinishedAt { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }

    public class OrderBuyer
    {
        public Guid BuyerId { get; set; }
        public string Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? CompanyName { get; set; }
        public bool Guest { get; set; }
        public string? PersonalIdentity { get; set; }
        public string PhoneNumber { get; set; }
        [NotMapped]
        public Preferences Preferences { get; set; }
        public virtual Address Address { get; set; }
    }

    public class Preferences
    {
        public string Langugage { get; set; }
    }

    public class Address
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string? City { get; set; }
        public string PostCode { get; set; }
        public string CountryCode { get; set; }
    }

    public class OrderPayment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Provider { get; set; }
        public DateTime FinishedAt { get; set; }
        public Paidamount PaidAmount { get; set; }
        public string? Reconciliation { get; set; }
    }

    public class Paidamount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
    }

    public class OrderFulfillment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Status { get; set; }
        public virtual Shipmentsummary ShipmentSummary { get; set; }
    }

    public class Shipmentsummary
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string LineItemsSent { get; set; }
    }

    public class OrderDelivery
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string MethodId { get; set; }
        public string MethodName { get; set; }
        public string PickupPointId { get; set; }
        public string PickupPointName { get; set; }
        public string PickupPointDescription { get; set; }
        public string PickupPointStreet { get; set; }
        public string PickupPointZipCode { get; set; }
        public string PickupPointCity { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CostAmount { get; set; }
        public string? CostCurrency { get; set; }
        public bool Smart { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string? City { get; set; }
        public string ZipCode { get; set; }
        public string CountryCode { get; set; }
        public string? CompanyName { get; set; }
        public string PhoneNumber { get; set; }
    }

    public class Address1
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string CountryCode { get; set; }
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        [NotMapped]
        public object ModifiedAt { get; set; }
    }

    public class Method
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
    }

    public class Pickuppoint
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Address2 Address { get; set; }
    }

    public class Address2
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
    }

    public class Cost
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
    }

    public class Time
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool Guaranteed { get; set; }
        public Dispatch Dispatch { get; set; }
    }

    public class Dispatch
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
    }

    public class Invoice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public bool Required { get; set; }
        public Address3? Address { get; set; }
    }

    public class Address3
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string CountryCode { get; set; }
        [NotMapped]
        public Company Company { get; set; }
        [NotMapped]
        public object NaturalPerson { get; set; }
    }

    public class Company
    {
        public string Name { get; set; }
        public string TaxId { get; set; }
    }

    public class Marketplace
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid MarketplaceId { get; set; }
        public string Id { get; set; }
    }

    public class OrderSummary
    {
        public string? Amount { get; set; }
        public string? Currency { get; set; }
    }

    public class OrderLineItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public virtual Offer Offer { get; set; }
        public int Quantity { get; set; }
        public Originalprice OriginalPrice { get; set; }
        public Price Price { get; set; }
        [NotMapped]
        public string Reconciliation { get; set; }
        [NotMapped]
        public object[] SelectedAdditionalServices { get; set; }
        [NotMapped]
        public object[] Vouchers { get; set; }
        public DateTime BoughtAt { get; set; }
    }

    public class OfferFromOrder
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public External External { get; set; }
        public object ProductSet { get; set; }
    }

    public class Originalprice
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Amount { get; set; }
        public string Currency { get; set; }
    }

    public class OrderDiscount
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public Guid Id { get; set; }
        public string Type { get; set; }
    }

}
