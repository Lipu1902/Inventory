using MediatR;

namespace Inventory.Modules.Products.Commands.DeleteProduct
{
    public class DeleteProductCommand:IRequest<string>
    {
        public int ProductId { get; set; }
    }
}
