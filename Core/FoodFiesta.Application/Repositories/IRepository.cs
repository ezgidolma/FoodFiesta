using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodFiesta.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace FoodFiesta.Application.Repositories
{
    // repository ile veritabanı işlemlerini bir yerden yapmayı amaçlayıp tekrarlardan kaçınılmaya çalışıldı.Tekrar tekrar veritabanı işlemlerini iş katmanında yazmamıza gerek kalmıyor
    public interface IRepository<T> where T: BaseEntity// burası Base repository gibi düşünülebilir
    {
        DbSet<T> Table { get; }
    }
}
