using MediatR;

namespace Inventory.Modules.Products.Query.GetProductList
{
    public class GetProductListQuery:IRequest<List<ProductListResponse>>
    {
    }
}
