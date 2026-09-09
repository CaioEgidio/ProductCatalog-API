using ProductCatalog.Application.Interfaces;
using ProductCatalog.Application.UseCases.CreateProduct;
using ProductCatalog.Application.UseCases.CreateSubProduct;
using ProductCatalog.Application.UseCases.CreateUser;
using ProductCatalog.Application.UseCases.GetAllProducts;
using ProductCatalog.Application.UseCases.GetAllUsers;
using ProductCatalog.Application.UseCases.GetProductById;
using ProductCatalog.Application.UseCases.GetSubProductsByProductId;
using ProductCatalog.Application.UseCases.GetUserById;
using ProductCatalog.Infrastructure.Repositories;

namespace ProductCatalog.API.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<GetAllUsersHandler>();
        services.AddScoped<GetAllProductsHandler>();
        services.AddScoped<CreateProductHandler>();
        services.AddScoped<GetProductByIdHandler>();
        services.AddScoped<CreateUserHandler>();
        services.AddScoped<GetUserByIdHandler>();
        services.AddScoped<CreateSubProductHandler>();
        services.AddScoped<GetSubProductsByProductIdHandler>();

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ISubProductRepository, SubProductRepository>();

        return services;
    }
}