using Google.Protobuf.WellKnownTypes;
using Inventory;
using Inventory.Persistence;
using Inventory.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(option =>
{
    option.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:key"]))
    };

});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICustomerInfoRepository, CustomerInfoRepository>();
builder.Services.AddScoped<ISaleMasterRepository, SaleMasterRepository>();
builder.Services.AddScoped<ISaleDetailsRepository, SaleDetailsRepository>();
builder.Services.AddScoped<IUserInfoRepository, UserInfoRepository>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddDbContext<InventoryDbContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("InventoryConnectionStringSQLSerVer")));
//string? _dbConnection = builder.Configuration.GetConnectionString("InventoryConnectionStringMYSQL");
//builder.Services.AddDbContext<InventoryDbContext>(options => options.UseMySql(_dbConnection, ServerVersion.AutoDetect(_dbConnection)));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
