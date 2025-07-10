using Inventory.Persistence;
using MediatR;

namespace Inventory.Modules.Sales.Query.SalesReport
{
    public class GetSalesReportQueryHandler : IRequestHandler<GetSalesReportQuery, SalesReportResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        public GetSalesReportQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<SalesReportResponse> Handle(GetSalesReportQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var result = new SalesReportResponse();
                var saleReport = (await _unitOfWork.SaleMasterRepository.ListAllAsync()).
                    Where(s => s.SaleDate.Date >= request.SaleDateFrom.Date && s.SaleDate.Date <= request.SaleDateTo.Date).ToList();
                if (saleReport.Count > 0)
                {
                    result = new SalesReportResponse();
                    result.NumberofTransactions = saleReport.Count;
                    result.TotalSales = saleReport.Sum(x => x.TotalAmount);
                    var saleMasterId = saleReport.Select(s => s.SaleId).ToList();

                    var getSaleDetails = (await _unitOfWork.SaleDetailsRepository.ListAllAsync()).
                        Where(d => saleMasterId.Contains(d.SaleMasterId)).ToList();

                    result.TotalRevenue = getSaleDetails.Sum(x =>(decimal) x.Price) - result.TotalSales;
                }
                return result;
            }
            catch (Exception ex)
            {
                return new SalesReportResponse();
            }
        }
    }
}
