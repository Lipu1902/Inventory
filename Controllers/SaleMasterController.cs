using Inventory.Modules.CustomerInfos.Command.CreateCustomerInfo;
using Inventory.Modules.Products.Query.GetProductListByBadcode;
using Inventory.Modules.Sales.Command.CreateSale;
using Inventory.Modules.Sales.Query.SalesReport;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleMasterController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SaleMasterController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] CreateSaleCommand createSaleCommand)
        {
            try
            {
                var createCommand = await _mediator.Send(createSaleCommand);
                return (createCommand);

            }
            catch (Exception ex)
            {
                return ("Could Not Add Sale");
            }
        }
        [HttpGet("GetSalesReportResponse{fromDate}/{toDate}", Name = "GetSalesReportResponse")]
        public async Task<ActionResult<SalesReportResponse>> GetSalesReportResponse(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var salesReport = await _mediator.Send(new GetSalesReportQuery() { SaleDateFrom = fromDate, SaleDateTo = toDate });
                return (salesReport);
            }
            catch (Exception ex)
            {
                return new SalesReportResponse();
            }
        }
    }
}
