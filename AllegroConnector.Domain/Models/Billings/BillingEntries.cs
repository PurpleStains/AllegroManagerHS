namespace AllegroConnector.Domain.Models.Billings
{
    public class BillingEntries
    {
        public List<BillingEntry> billingEntries { get; set; }
    }

    public class Balance
    {
        public string amount { get; set; }
        public string currency { get; set; }
    }

    public class BillingEntry
    {
        public string id { get; set; }
        public DateTime occurredAt { get; set; }
        public Type type { get; set; }
        public Offer offer { get; set; }
        public Value value { get; set; }
        public Tax tax { get; set; }
        public Balance balance { get; set; }
        public Order order { get; set; }
    }

    public class Offer
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Order
    {
        public string id { get; set; }
    }

    public class Tax
    {
        public string percentage { get; set; }
    }

    public class Type
    {
        public string id { get; set; }
        public string name { get; set; }
    }

    public class Value
    {
        public string amount { get; set; }
        public string currency { get; set; }
    }
}
