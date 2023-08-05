﻿using FoodFiesta.Application.Repositories;
using FoodFiesta.Domain.Entities.Common;
using FoodFiesta.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodFiesta.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly FoodFiestaDbContext _context;

        public WriteRepository(FoodFiestaDbContext context)
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();

        public async Task<bool> AddAsync(T model)
        {
          EntityEntry<T> entityEntry  =  await Table.AddAsync(model);
            return entityEntry.State==EntityState.Added;
        }

        public bool Update(T model)
        {
            EntityEntry<T> entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }

        public bool Remove(T model)
        {
            EntityEntry<T> entityEntry = Table.Remove(model);
            return entityEntry.State != EntityState.Deleted;
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);
            return true;
        }

      
        public bool RemoveRange(List<T> datas)
        {
           Table.RemoveRange(datas);
            return true;
        }

        public  async Task<bool> RemoveAsync(string id)
        {
           T model =  await Table.FirstOrDefaultAsync(data => data.Id==Guid.Parse(id));
            return Remove(model);
        }


        public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();

      
    }
}
