using MediatR;

namespace Inventory.Modules.Sales.Query.SalesReport
{
    public class GetSalesReportQuery:IRequest<SalesReportResponse>
    {
        public DateTime SaleDateFrom { get; set; }
        public DateTime SaleDateTo { get; set; }
    }
}
