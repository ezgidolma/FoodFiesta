﻿using FoodFiesta.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodFiesta.Domain.Entities
{
    public class Product : BaseEntity
    {
        public String Name { get; set; }

        public int Stock { get; set; }

        public float  Price { get; set; }


        public ICollection<Order> Orders { get; set; } // çoka çok ilişkide karşılıklı ICollection yapılır
    }
}
