using Arvefordeleren_ClassLibrary.Models;
using Arvefordeleren_WebAPI.Controllers;
using Arvefordeleren_WebAPI.Persistance;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IRepository<Asset>, Repository<Asset>>();
builder.Services.AddSingleton<IRepository<Testator>, Repository<Testator>>();
builder.Services.AddSingleton<IRepository<Heir>, Repository<Heir>>();

builder.Services.AddScoped<TestatorController>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
