using FoodFiesta.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodFiesta.Application.Repositories
{
    public interface IWriteRepository<T> :IRepository<T> where T: BaseEntity // ekleme, silme ve  güncelleme operasyonlarını yapma   
    {
        Task<bool> AddAsync(T model);// eklenen model neyse onu ekler

        Task<bool> AddRangeAsync(List<T> datas);

        bool Remove(T model);

        bool RemoveRange(List<T> datas);    

        Task<bool> RemoveAsync(string id);

        bool Update(T model);

        Task<int> SaveAsync();
    }
}
