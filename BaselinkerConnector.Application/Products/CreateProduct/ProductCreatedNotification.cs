using AllegroConnector.BuildingBlocks.Application.Events;
using BaselinkerConnector.Domain.Products.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaselinkerConnector.Application.Products.CreateProduct
{
    public class ProductCreatedNotification : DomainNotificationBase<ProductCreatedDomainEvent>
    {
        [JsonConstructor]
        public ProductCreatedNotification(ProductCreatedDomainEvent domainEvent, Guid id) : base(domainEvent, id)
        {
        }
    }
}
