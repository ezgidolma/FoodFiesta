using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodFiesta.Domain.Entities.Common
{
    public class BaseEntity
    {
        public Guid Id { get; set; } //Unique identitfy C# ta Guid olarak geçer
        public DateTime CreateDate { get; set; } //oluşturulma tarihi
        public DateTime UpdateDate { get; set; }//güncellenme tarihi

    }
}
