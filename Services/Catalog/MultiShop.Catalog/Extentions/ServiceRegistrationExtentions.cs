﻿using MultiShop.Catalog.Services.AboutServices;
using MultiShop.Catalog.Services.BrandServices;
using MultiShop.Catalog.Services.CategoryServices;
using MultiShop.Catalog.Services.ContactServices;
using MultiShop.Catalog.Services.FeatureServices;
using MultiShop.Catalog.Services.FeatureSliderServices;
using MultiShop.Catalog.Services.OfferDiscountServices;
using MultiShop.Catalog.Services.ProductDetailServices;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Services.ProductServices;
using MultiShop.Catalog.Services.SpecialOfferServices;

namespace MultiShop.Catalog.Extentions;

public static class ServiceRegistrationExtentions
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IProductDetailService, ProductDetailService>();
        services.AddScoped<IProductImageService, ProductImageService>();
        services.AddScoped<IFeatureSliderService, FeatureSliderService>();
        services.AddScoped<ISpecialOfferService, SpecialOfferService>();
        services.AddScoped<IFeatureService, FeatureService>();
        services.AddScoped<IOfferDiscountService, OfferDiscountService>();
        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<IAboutService, AboutService>();
        services.AddScoped<IContactService, ContactService>();
    }
}
