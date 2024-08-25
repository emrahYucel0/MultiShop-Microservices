﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService _productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            _productImageService = productImageService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var values = await _productImageService.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageByIdAsync(string id)
        {
            var values = await _productImageService.GetByIdProductImageAsync(id);
            return Ok(values);
        }

        [HttpGet("ProductImagesByProductId")]
        public async Task<IActionResult> ProductImagesByProductId(string id)
        {
            var values = await _productImageService.GetByProductIdProductImageAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            await _productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("Ürün Görseli Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductImageAsync(string id)
        {
            await _productImageService.DeleteProductImageAsync(id);
            return Ok("Ürün Görseli Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            await _productImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Ürün Görseli Başarıyla Güncellendi");
        }
    }
}
