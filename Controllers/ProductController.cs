using Inventory.Modules.Products.Commands.CreateProduct;
using Inventory.Modules.Products.Commands.DeleteProduct;
using Inventory.Modules.Products.Commands.UpdateProduct;
using Inventory.Modules.Products.Query.GetProductList;
using Inventory.Modules.Products.Query.GetProductListByBadcode;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] CreateProductCommand createProductCommand)
        {
            try
            {
                var createCommand = await _mediator.Send(createProductCommand);
                if (createCommand > 0)
                {
                    return Ok("Add Product Successfully");
                }
                else
                {
                    return ("Barcode already exists !!");
                }

            }
            catch (Exception ex)
            {
                return ("Could Not Add Product");
            }
        }
        [HttpPut]
        public async Task<ActionResult<string>> Put([FromBody] UpdateProductCommand updateProductCommand)
        {
            try
            {
                var createCommand = await _mediator.Send(updateProductCommand);

                return Ok(createCommand);

            }
            catch (Exception ex)
            {
                return ("Could Not update Product");
            }
        }
        [HttpDelete("ProductId")]
        public async Task<ActionResult<string>> Delete(int ProductId)
        {
            try
            {
                var deleteCommand = await _mediator.Send(new DeleteProductCommand() { ProductId = ProductId });
                return Ok(deleteCommand);
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<ProductListResponse>>> Get()
        {
            try
            {
                var allProduct = await _mediator.Send(new GetProductListQuery());
                return (allProduct);
            }
            catch (Exception ex)
            {
                return new List<ProductListResponse>();
            }
        }
        [HttpGet("GetProductByBarCode{barcode}", Name = "GetProductByBarCode")]
        public async Task<ActionResult<List<ProductListByBadcodeResponse>>> GetProductByBarCode(string barcode)
        {
            try
            {
                var allProductByBarcode = await _mediator.Send(new GetProductListByBadcodeQuery() { Barcode = barcode });
                return (allProductByBarcode);
            }
            catch (Exception ex)
            {
                return new List<ProductListByBadcodeResponse>();
            }
        }
    }
}
