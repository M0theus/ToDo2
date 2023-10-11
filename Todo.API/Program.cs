using Microsoft.EntityFrameworkCore;
using ToDo.Domain.Contracts.Repositories;
using ToDo.Infra;
using ToDo.Infra.Context;
using ToDo.Infra.Repository;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddInfraData(builder.Configuration.GetConnectionString("ConnectionString"));

// Add services to the container.

builder.Services.AddControllers();
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