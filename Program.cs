var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// exemplo da minha api
var users = new List<object>
{
    new { Id = Guid.NewGuid(), nome = "caio", email = "caio@email.com" }
};

var products = new List<object>
{
    new { Id = Guid.NewGuid(), Nome = "Notebook", preco = 3500 }
};
app.MapGet("/users", () => users);
app.MapGet("/products", () => products);

app.Run();


