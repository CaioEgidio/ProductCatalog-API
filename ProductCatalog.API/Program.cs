using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ProductCatalog.Infrastructure.Persistence;
using ProductCatalog.Application.UseCases.CreateProduct;
using ProductCatalog.Application.Interfaces;
using ProductCatalog.Infrastructure.Repositories;
using ProductCatalog.Application.UseCases.GetAllProducts;
using ProductCatalog.Application.UseCases.GetProductById;
using ProductCatalog.Application.UseCases.CreateUser;
using ProductCatalog.Application.UseCases.GetAllUsers;
using ProductCatalog.Application.UseCases.GetUserById;
using ProductCatalog.Application.UseCases.CreateSubProduct;


// Cria o "construtor" da aplicação, responsável por configurar tudo antes de rodar
var builder = WebApplication.CreateBuilder(args);


// Registra o banco de dados (EF Core) usando PostgreSQL,
// pegando a string de conexão do appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(
        builder.Configuration.GetConnectionString("DefaultConnection")));


// Registra os handlers dos casos de uso.
builder.Services.AddScoped<GetAllUsersHandler>();
builder.Services.AddScoped<GetAllProductsHandler>();
builder.Services.AddScoped<CreateProductHandler>();
builder.Services.AddScoped<GetProductByIdHandler>();
builder.Services.AddScoped<CreateUserHandler>();
builder.Services.AddScoped<GetUserByIdHandler>();
builder.Services.AddScoped<CreateSubProductHandler>();

// Registra os repositórios.
// Quando uma classe solicitar uma interface, o .NET
// fornece a implementação correspondente.
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ISubProductRepository, SubProductRepository>();

// Add services to the container.

// Habilita o uso de Controllers (endpoints da API)
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

// Necessário para o Swagger conseguir "ler" os endpoints da API
builder.Services.AddEndpointsApiExplorer();

// Configura o Swagger (documentação interativa da API)
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Product Catalog API",
        Version = "v1",
        Description = "### Bem-vindo à API Product Catalog!\n\n" +
                      "API REST desenvolvida em .NET 8 para gerenciamento de produtos.\n\n" +
                      "* **Arquitetura:** DDD Simplificado\n" +
                      "* **Tecnologias:** ASP.NET Core, Entity Framework Core e PostgreSQL\n" +
                      "* **Objetivo:** Praticar boas práticas de arquitetura, separação de responsabilidades e persistência de dados\n" +
                      "* **Status:** Em desenvolvimento"
        
    });
});



// A partir daqui, a aplicação é "construída" com tudo que foi configurado acima
var app = builder.Build();

// Só habilita Swagger se estiver rodando em ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redireciona requisições HTTP para HTTPS automaticamente
//app.UseHttpsRedirection();

// Habilita verificação de autorização (ainda sem regras configuradas)
app.UseAuthorization();

// Mapeia as rotas dos Controllers (ex: [HttpGet], [HttpPost])
app.MapControllers();

// Inicia a aplicação e mantém ela "escutando" requisições
app.Run();