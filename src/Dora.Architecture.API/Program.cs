using Dora.Architecture.API;
using Dora.Architecture.Application;
using Dora.Architecture.EntityFrameworkCore;
using Dora.Architecture.Infrastructure;
using Hangfire;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddEfCore()
    .AddInfrastructure()
    .AddApplication()
    .AddWebApiServices();

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

app.UseHangfireDashboard();

app.UseAuthorization();

app.MapControllers();

app.Run();
