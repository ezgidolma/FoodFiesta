﻿
using FoodFiesta.Application.Repositories;
using FoodFiesta.Application.ViewModels.Products;
using FoodFiesta.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FoodFiesta.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : Controller //IOC Container bu katmanda var //IOC containera diyoruzki IProductService türünden bir talep gelirse buna karşılık ProductService nesnesinden gönder.
    {
        
        readonly private IProductReadRepository _productReadRepository;
        readonly private IProductWriteRepository _productWriteRepository;

        public ProductsController(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
           return Ok(_productReadRepository.GetAll(false));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(_productReadRepository.GetByIdAsync(id,false));
        }

        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product model)
        {
            if (ModelState.IsValid)
            {
                 
            }
            await _productWriteRepository.AddAsync(new()
            {
                Name= model.Name,
                Price= model.Price,
                Stock= model.Stock
            });
            await _productWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);  
        }

        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Product model)
        {
            Product product = await _productReadRepository.GetByIdAsync(model.Id);
            product.Name = model.Name;
            product.Price = model.Price;
            product.Stock = model.Stock;
            await _productWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
             await _productWriteRepository.RemoveAsync(id);
            _productWriteRepository.SaveAsync();
            return Ok();
        }

    }
}
