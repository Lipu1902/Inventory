using MediatR;

namespace Inventory.Modules.UserInfos.Command.CreateLogin
{
    public class CreateLoginCommand:IRequest<string>
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
