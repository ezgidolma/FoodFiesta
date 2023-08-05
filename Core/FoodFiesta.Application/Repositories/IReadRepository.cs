using FoodFiesta.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FoodFiesta.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity // bir veritabanından select ile edinilen bilgilere read işlemler denir
    {
        //IQueryable ile sorgular direkt olarak server üzerinden çalıştırılır
        IQueryable<T> GetAll(bool tracking=true);//hangi  türdeysek bütün şeyleri getir demek

        IQueryable<T> GetWhere(Expression<Func<T,bool>>method, bool tracking = true);//getwhere ifadesinde verilen şart ifadesi doğruysa veriler getiriliyor.

        Task<T> GetSingleAsync(Expression<Func<T,bool>>method, bool tracking = true);//şarta uygun olan ilki getir

        Task<T> GetByIdAsync(string id, bool tracking = true);// verilen idyi getir
    }
}
