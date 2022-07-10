using ComissionCalculator.ApiModels;
using ComissionCalculator.Configuration;
using ComissionCalculator.DAL;
using ComissionCalculator.DAL.Seed;
using ComissionCalculator.Mapper;
using ComissionCalculator.Models;
using ComissionCalculator.Services;
using ComissionCalculator.Services.Contracts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ComissionDbContext>(options => options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Comission;Trusted_Connection=True;"));
builder.Services.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

SeedDb(app);

app.Run();


void SeedDb(WebApplication app)
{
    using(var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var dbContext = services.GetRequiredService<ComissionDbContext>();
        DbSeeder.Seed(dbContext);
    }
}