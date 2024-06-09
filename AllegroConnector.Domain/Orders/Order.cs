using AllegroConnector.BuildingBlocks.Domain;

namespace AllegroConnector.Domain.Orders
{
    public class Order : Entity, IAggregateRoot
    {
        public Guid Id { get; private set; }
        public string? Email { get; private set; }
        public string? FirstName { get; private set; }
        public string? LastName { get; private set; }
        public string? Login { get; private set; }
        public string? TotalToPay { get; private set; }
        public string Status { get; private set; }
        public string AllegroFee { get; private set; }
        public string? Margin { get; private set; }
        public DateTimeOffset UpdatedAt { get; private set; }
        public virtual ICollection<OrderLineItem> LineItems { get; private set; }

        private Order(Guid id, ICollection<OrderLineItem> lineItems)
        {
            Id = id;
            LineItems = lineItems;
        }

        private Order(Guid id,
            string email,
            string firstName,
            string lastName,
            string login,
            string totalToPay,
            string status,
            string allegroFee,
            DateTimeOffset updatedAt
            )
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
            Login = login;
            TotalToPay = totalToPay;
            Status = status;
            AllegroFee = allegroFee;
            UpdatedAt = updatedAt;
        }

        public static Order Create(Guid id,
            string email,
            string firstName,
            string lastName,
            string login,
            string totalToPay,
            string status,
            string allegroFee,
            DateTimeOffset updatedAt) => new Order(id,
                email, firstName, lastName, login, totalToPay, status, allegroFee, updatedAt);
        
        public void AddOrderLineItems(List<OrderLineItem> lineItem)
        {
            LineItems = new List<OrderLineItem>(lineItem);
        }

        public void SetMargin(string margin)
        {
            Margin = margin;
        }

    }
}
