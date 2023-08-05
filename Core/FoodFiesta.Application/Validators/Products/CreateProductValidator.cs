﻿using FluentValidation;
using FoodFiesta.Application.ViewModels.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodFiesta.Application.Validators.Products
{
    public class CreateProductValidator :AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator() 
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .NotNull()
                    .WithMessage("Lütfen ürün adını boş geçmeyiniz.")
                .MaximumLength(150)
                .MinimumLength(2)
                    .WithMessage("Lütfen ürün adını 2 ile 150 karakter arasında giriniz.");

            RuleFor(p => p.Stock)
                 .NotEmpty()
                 .NotNull()
                     .WithMessage("Lütfen stock bilgisini boş geçmeyiniz.")
                 .Must(s => s >= 0)
                     .WithMessage("Stock bilgisi negatif olamaz.");

            RuleFor(p => p.Price)
                 .NotEmpty()
                 .NotNull()
                     .WithMessage("Lütfen fiyat bilgisini boş geçmeyiniz.")
                 .Must(s => s >= 0)
                     .WithMessage("Fiyat bilgisi negatif olamaz.");

        }
    }
}
