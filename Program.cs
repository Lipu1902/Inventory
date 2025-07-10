using Inventory;
using Inventory.Persistence;
using Inventory.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICustomerInfoRepository, CustomerInfoRepository>();
builder.Services.AddScoped<ISaleMasterRepository, SaleMasterRepository>();
builder.Services.AddScoped<ISaleDetailsRepository, SaleDetailsRepository>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
//builder.Services.AddDbContext<InventoryDbContext>(options => options.UseSqlServer(
//builder.Configuration.GetConnectionString("InventoryConnectionString")));
string? _dbConnection = builder.Configuration.GetConnectionString("InventoryConnectionString");
builder.Services.AddDbContext<InventoryDbContext>(options => options.UseMySql(_dbConnection, ServerVersion.AutoDetect(_dbConnection)));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
