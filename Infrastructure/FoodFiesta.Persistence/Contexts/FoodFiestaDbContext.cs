using FoodFiesta.Domain.Entities;
using FoodFiesta.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodFiesta.Persistence.Contexts
{
    public class FoodFiestaDbContext : DbContext//bunu IOC containera koymalıyız ki her yerden erişelim
    {
        public FoodFiestaDbContext(DbContextOptions options) : base(options)// bu constructor IOC Containerda doldurulacak
        {
        }

        public DbSet<Product> Products { get; set; } //DbContexte diyorki Product formatındaki tablonun adı Products

        public DbSet<Order> Orders { get; set; }

        public DbSet<Customer> Customers { get; set; }

        //gelen isteğe göre doldurma mesela insert geliyorsa crateDate  update geliyorsa updateDate kolonlarını doldurcak
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            //entityler üzerinden yapılan değişikliklerin ya da yeni eklenen verinin yakalanmasını sağlayan propertydir.Update operasyonlarında track edilen verileri yakalayıp elde etmemizi sağlar.
            var data = ChangeTracker.Entries<BaseEntity>();

            foreach (var item in data)
            {
                var result = item.State switch
                {
                    EntityState.Added => item.Entity.CreateDate=DateTime.UtcNow,
                    EntityState.Modified=>item.Entity.UpdateDate=DateTime.UtcNow,
                    _ =>DateTime.UtcNow
                };
              
            }
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
