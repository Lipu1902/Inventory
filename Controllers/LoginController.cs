using Inventory.Modules.CustomerInfos.Command.CreateCustomerInfo;
using Inventory.Modules.UserInfos.Command.CreateLogin;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Inventory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] CreateLoginCommand createLoginCommand)
        {
            try
            {
                var createCommand = await _mediator.Send(createLoginCommand);
                return (createCommand);

            }
            catch (Exception ex)
            {
                return ("Could Not Add Customer");
            }
        }
    }
}
