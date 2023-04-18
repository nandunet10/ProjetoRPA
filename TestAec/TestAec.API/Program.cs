using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using TestAec.API.Models;
using TestAec.API.Queries.Abstractions;
using TestAec.API.Queries.Concrete;
using TestAec.Domain.AggregatesModel;
using TestAec.Infrastructure.Contexts;
using TestAec.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<DadosBase>(builder.Configuration.GetSection("DadosBase"));

builder.Services.AddDbContext<Context>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

builder.Services.AddScoped<IRepository<Card>, CardRepository>();
builder.Services.AddScoped<ICardQuery, CardQuery>();

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
