using Inventory.Persistence;
using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Inventory.Modules.UserInfos.Command.CreateLogin
{
    public class CreateLoginCommandHandler : IRequestHandler<CreateLoginCommand, string>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        public CreateLoginCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }
        public async Task<string> Handle(CreateLoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var checkLogin = (await _unitOfWork.UserInfoRepository.ListAllAsync()).
                    Where(u => u.UserName == request.UserName && u.Password == request.Password).FirstOrDefault();
                if (checkLogin != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub,_configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                        new Claim("Id",checkLogin.Id.ToString()),
                        new Claim("UserName",checkLogin.UserName.ToString()),
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.Now.AddMinutes(5),
                        signingCredentials: signIn
                        );
                    string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);
                    return (tokenValue);
                }
                return "";
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}
