using Microsoft.EntityFrameworkCore;
using OrderCaseRepo.Business.Services;
using OrderCaseRepo.Business.Services.Interfaces;
using OrderCaseRepo.Data.Repositories.Contexts;
using OrderCaseRepo.Extensions;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICatalogService, CatalogService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddDbContext<OrderDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration["OrderDbConnectionString"]);
});
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.SeedDb();

app.MapControllers();

app.Run();
