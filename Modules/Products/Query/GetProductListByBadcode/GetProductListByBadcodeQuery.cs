using MediatR;

namespace Inventory.Modules.Products.Query.GetProductListByBadcode
{
    public class GetProductListByBadcodeQuery:IRequest<List<ProductListByBadcodeResponse>>
    {
        public string Barcode { get; set; } = string.Empty;
    }
}
