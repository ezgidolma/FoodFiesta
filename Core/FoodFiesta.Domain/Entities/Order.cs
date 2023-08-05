using FoodFiesta.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodFiesta.Domain.Entities
{
    public class Order:BaseEntity
    {
        public Guid CustomerId { get; set; }
        public string Description { get; set; }

        public string Address { get; set; }

        public ICollection<Product> Products { get; set; }  // bunun anlamı bir order'ın birden fazla productı var demek

        public Customer Customer { get; set; } //Siparişin bir müşterisi olabilir 1-n ilişkisi (tekilleme)
    }
}
