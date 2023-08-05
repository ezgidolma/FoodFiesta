﻿using FoodFiesta.Application.Repositories;
using FoodFiesta.Domain.Entities;
using FoodFiesta.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodFiesta.Persistence.Repositories
{
    public class CustomerReadRepository : ReadRepository<Customer>, ICustomerReadRepository
    {
        public CustomerReadRepository(FoodFiestaDbContext context) : base(context)
        {
        }
    }
}
