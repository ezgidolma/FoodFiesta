using FluentValidation.AspNetCore;
using FoodFiesta.Application.Validators.Products;
using FoodFiesta.Infrastructure.Filters;
using FoodFiesta.Persistence;
using FoodFiesta.Persistence.Contexts;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

//IOC container için ServiceRegistration tetiklenmeli burada
builder.Services.AddPersistenceServices();

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<CreateProductValidator>())
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter=true);
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

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
        => services.AddDbContext<FoodFiestaDbContext>();
}

