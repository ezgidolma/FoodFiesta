
using FoodFiesta.Application.Repositories;
using FoodFiesta.Persistence.Contexts;
using FoodFiesta.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FoodFiesta.Persistence
{
    public static class ServiceRegistration//static olma nedeni excention fonksiyon tanımlayacak olmamız
    {
        public static void AddPersistenceServices(this IServiceCollection services)//IOC containerın görevi IProductService gelirse ProductService türünde nesne gönder diyoruz
        {

            // burada hangi veritabını kullanacaksak nugetten indirip projeye dahil etmemiz lazım
            services.AddDbContext<FoodFiestaDbContext>(options => options.UseNpgsql("User ID=postgres;Password=12345;Host=localhost;Port=5432;Database=FoodFiestaDb;"));
            services.AddScoped<ICustomerReadRepository,CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
        }
    }
}
