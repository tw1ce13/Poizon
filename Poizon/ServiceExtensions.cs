using System;
using Poizon.DAL.Implementations;
using Poizon.DAL.Interfaces;
using Poizon.Services.Implementations;
using Poizon.Services.Interfaces;

namespace Poizon;

public static class ServiceExtensions
{
    public static void AddMyLibraryServices(this IServiceCollection services)
    {
        services.AddSession();

        services.AddScoped<IBrandService, BrandService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IClothesService, ClothesService>();
        services.AddScoped<IModelService, ModelService>();
        services.AddScoped<IOrderClothesService, OrderClothesService>();
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<ISexService, SexService>();
        services.AddScoped<ISizeService, SizeService>();
        services.AddScoped<IStyleService, StyleService>();
        services.AddScoped<ISubCategoryService, SubCategoryService>();
        services.AddScoped<IUserInfoService, UserInfoService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ISubSubCategoryService, SubSubCategoryService>();
        services.AddScoped<IAccountService, AccountService>();

        services.AddTransient<IBrandRepository, BrandRepository>();
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddTransient<IClothesRepository, ClothesRepository>();
        services.AddTransient<IModelRepository, ModelRepository>();
        services.AddTransient<IOrderClothesRepository, OrderClothesRepository>();
        services.AddTransient<IOrderRepository, OrderRepository>();
        services.AddTransient<ISexRepository, SexRepository>();
        services.AddTransient<ISizeRepository, SizeRepository>();
        services.AddTransient<IStyleRepository, StyleRepository>();
        services.AddTransient<ISubCategoryRepository, SubCategoryRepository>();
        services.AddTransient<IUserInfoRepository, UserInfoRepository>();
        services.AddTransient<IUserRepository, UserRepository>();
        services.AddTransient<ISubSubCategoryRepository, SubSubCategoryRepository>();
    }
}
