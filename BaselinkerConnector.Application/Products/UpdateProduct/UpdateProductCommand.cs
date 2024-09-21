using BaselinkerConnector.Application.Configuration.Commands;
using Newtonsoft.Json;

namespace BaselinkerConnector.Application.Products.UpdateProduct
{
    public class UpdateProductCommand : InternalCommandBase
    {
        [JsonConstructor]
        public UpdateProductCommand(Guid id, Guid productId) : base(id)
        { 
            ProductId = productId;
        }

        public Guid ProductId { get; }
    }
}
