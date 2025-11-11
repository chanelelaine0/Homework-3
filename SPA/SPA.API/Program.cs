using Microsoft.EntityFrameworkCore;
using SPA.Infrastructure.Context;
using SPA.Infrastructure.Repositories;
using SPA.Domain.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SpaContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
