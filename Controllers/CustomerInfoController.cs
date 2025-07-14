using Inventory.Modules.CustomerInfos.Command.CreateCustomerInfo;
using Inventory.Modules.CustomerInfos.Command.DeleteCustomerInfo;
using Inventory.Modules.CustomerInfos.Command.UpdateCustomerInfo;
using Inventory.Modules.CustomerInfos.Query.GetCustomerInfoList;
using Inventory.Modules.Products.Commands.CreateProduct;
using Inventory.Modules.Products.Commands.DeleteProduct;
using Inventory.Modules.Products.Commands.UpdateProduct;
using Inventory.Modules.Products.Query.GetProductList;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerInfoController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomerInfoController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] CreateCustomerInfoCommand createCustomerInfoCommand)
        {
            try
            {
                var createCommand = await _mediator.Send(createCustomerInfoCommand);
                return (createCommand);

            }
            catch (Exception ex)
            {
                return ("Could Not Add Customer");
            }
        }
        [HttpPut]
        public async Task<ActionResult<string>> Put([FromBody] UpdateCustomerInfoCommand updateCustomerInfoCommand)
        {
            try
            {
                var createCommand = await _mediator.Send(updateCustomerInfoCommand);

                return Ok(createCommand);

            }
            catch (Exception ex)
            {
                return ("Could Not update Customer");
            }
        }
        [HttpDelete("CustomerId")]
        public async Task<ActionResult<string>> Delete(int CustomerId)
        {
            try
            {
                var deleteCommand = await _mediator.Send(new DeleteCustomerInfoCommand() { CustomerId = CustomerId });
                return Ok(deleteCommand);
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<CustomerInfoListResponse>>> Get()
        {
            try
            {
                var allCustomer = await _mediator.Send(new GetCustomerInfoListQuesry());
                return (allCustomer);
            }
            catch (Exception ex)
            {
                return new List<CustomerInfoListResponse>();
            }
        }
    }
}
