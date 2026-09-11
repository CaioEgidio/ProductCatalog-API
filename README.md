# ProductCatalog API

API REST desenvolvida em **C# com .NET 8 e ASP.NET Core**, criada como projeto de estudo e portfólio para praticar desenvolvimento backend, arquitetura em camadas, DDD, SOLID, Entity Framework Core, PostgreSQL, Repository Pattern e Dependency Injection.

A aplicação possui gerenciamento de **usuários, produtos e subprodutos**, com persistência em banco de dados relacional e documentação interativa através do Swagger/OpenAPI.

---

## bjetivo

O projeto foi desenvolvido com foco no aprendizado e aplicação prática de conceitos utilizados no desenvolvimento de APIs backend profissionais.

Entre os principais objetivos estão:

- Desenvolver uma API REST utilizando .NET 8
- Aplicar conceitos de DDD e SOLID
- Trabalhar com separação de responsabilidades
- Utilizar Entity Framework Core para persistência de dados
- Trabalhar com PostgreSQL
- Implementar Repository Pattern
- Utilizar Dependency Injection
- Criar validações de entrada
- Trabalhar com migrations
- Documentar e testar a API através do Swagger

---

## Tecnologias

### Backend

- **C#**
- **.NET 8**
- **ASP.NET Core**
- **Entity Framework Core 8**
- **PostgreSQL**
- **Npgsql**
- **FluentValidation**
- **Swagger / OpenAPI**

### Arquitetura e padrões

- Domain-Driven Design (DDD)
- SOLID
- Repository Pattern
- Dependency Injection
- Separação de responsabilidades
- Arquitetura em camadas

### Ferramentas

- Git
- GitHub
- JetBrains Rider
- PostgreSQL / pgAdmin
- Entity Framework Core CLI

---

## Arquitetura

O projeto é dividido em quatro projetos principais:

```text
ProductCatalog.API
        ↓
ProductCatalog.Application
        ↓
ProductCatalog.Domain

ProductCatalog.Infrastructure
        ↓
Application + Domain
```

### ProductCatalog.API

Responsável pela camada de apresentação da aplicação.

Contém:

- Controllers
- Middleware
- Configurações da aplicação
- Configuração do Swagger
- Configuração do pipeline HTTP
- `Program.cs`

A API é responsável por receber as requisições HTTP e encaminhá-las para a camada de Application.

---

### ProductCatalog.Application

Contém os casos de uso e contratos utilizados pela aplicação.

Principais componentes:

- DTOs
- Interfaces
- Use Cases
- Handlers
- Validators

Essa camada concentra a lógica de aplicação sem depender diretamente da implementação do banco de dados.

---

### ProductCatalog.Domain

Representa o núcleo do sistema.

Contém:

- Entidades
- Interfaces de domínio
- Regras e validações relacionadas às entidades
- Exceções de domínio

A camada de Domain não possui dependência das outras camadas.

---

### ProductCatalog.Infrastructure

Responsável pelos detalhes de infraestrutura e persistência.

Contém:

- `DbContext`
- Repositories
- Configurações do Entity Framework Core
- Migrations
- Configuração do PostgreSQL

Essa camada implementa as interfaces definidas pela Application.

---

## Modelo de domínio

A aplicação possui três entidades principais:

```text
User
 │
 └── Products
       │
       └── SubProducts
```

### User

Representa o usuário responsável pelos produtos cadastrados.

Principais propriedades:

- `Id`
- `Nome`
- `Email`
- `DataCriacao`

Regras:

- Nome é obrigatório
- Email é obrigatório
- Email possui índice único no banco

---

### Product

Representa um produto pertencente a um usuário.

Principais propriedades:

- `Id`
- `Nome`
- `Descricao`
- `Preco`
- `UserId`
- `DataCriacao`

Regras:

- Nome é obrigatório
- Preço deve ser maior que zero
- O produto deve estar associado a um usuário existente

---

### SubProduct

Representa um subproduto associado a um produto.

Principais propriedades:

- `Id`
- `Nome`
- `ProductId`
- `PrecoAdicional`

Regras:

- Nome é obrigatório
- O subproduto deve pertencer a um produto existente
- `PrecoAdicional` não pode ser negativo

---

# Endpoints

## Users

### Criar usuário

```http
POST /users
```

Exemplo:

```json
{
  "nome": "Caio Egidio",
  "email": "caio@example.com"
}
```

### Listar usuários

```http
GET /users
```

### Buscar usuário por ID

```http
GET /users/{id}
```

---

## Products

### Criar produto

```http
POST /products
```

Exemplo:

```json
{
  "nome": "Notebook Gamer",
  "descricao": "Notebook para jogos e desenvolvimento",
  "preco": 5999.90,
  "userId": "00000000-0000-0000-0000-000000000000"
}
```

### Listar produtos

```http
GET /products
```

### Buscar produto por ID

```http
GET /products/{id}
```

---

## SubProducts

Os subprodutos são relacionados diretamente a um produto através da rota.

### Criar subproduto

```http
POST /products/{productId}/subproducts
```

Exemplo:

```json
{
  "nome": "Mouse Gamer",
  "precoAdicional": 299.90
}
```

### Listar subprodutos de um produto

```http
GET /products/{productId}/subproducts
```

---

# Banco de dados

O projeto utiliza **PostgreSQL** como banco de dados relacional.

O acesso ao banco é realizado através do:

- Entity Framework Core
- Npgsql
- `AppDbContext`
- Repository Pattern

As configurações das entidades são separadas utilizando:

```csharp
IEntityTypeConfiguration<T>
```

As migrations do Entity Framework Core ficam armazenadas no projeto:

```text
ProductCatalog.Infrastructure
└── Migrations
```

---

# Migrations

Para criar uma nova migration:

```bash
dotnet ef migrations add NomeDaMigration \
  --project ProductCatalog.Infrastructure \
  --startup-project ProductCatalog.API
```

Para aplicar as migrations no banco:

```bash
dotnet ef database update \
  --project ProductCatalog.Infrastructure \
  --startup-project ProductCatalog.API
```

---

# Configuração

## 1. Clonar o repositório

```bash
git clone https://github.com/CaioEgidio/ProductCatalog-API.git
```

## 2. Entrar no projeto

```bash
cd ProductCatalog-API
```

## 3. Configurar o PostgreSQL

Crie um banco PostgreSQL para a aplicação e configure a connection string da aplicação.

A configuração fica em:

```text
ProductCatalog.API/appsettings.json
```

Exemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=ProductCatalogDb;Username=postgres;Password=SUA_SENHA"
  }
}
```

> Para ambientes reais, credenciais não devem ser armazenadas diretamente no código-fonte. O projeto utiliza essa configuração dessa forma atualmente por ser um projeto de estudo.

---

# Executando a aplicação

Na raiz do projeto:

```bash
dotnet restore
```

Depois:

```bash
dotnet build
```

Aplique as migrations:

```bash
dotnet ef database update \
  --project ProductCatalog.Infrastructure \
  --startup-project ProductCatalog.API
```

Execute a API:

```bash
dotnet run --project ProductCatalog.API
```

A aplicação estará disponível na URL indicada pelo ASP.NET Core no terminal.

---

# Swagger

Após iniciar a aplicação, acesse:

```text
/swagger
```

O Swagger fornece uma interface interativa para visualizar e testar os endpoints disponíveis na API.

Através dele é possível testar:

- Users
- Products
- SubProducts
- Criação de registros
- Consultas por ID
- Relacionamentos entre entidades

---

# Conceitos aplicados

Durante o desenvolvimento do projeto foram aplicados conceitos importantes de desenvolvimento backend:

### DDD

Separação entre:

- Domain
- Application
- Infrastructure
- API

### SOLID

Aplicação de responsabilidades bem definidas e dependências baseadas em abstrações.

### Dependency Injection

As dependências são registradas e injetadas através do sistema de DI do ASP.NET Core.

### Repository Pattern

O acesso aos dados é abstraído através de interfaces de Repository na camada de Application, enquanto suas implementações ficam na Infrastructure.

### Use Cases / Handlers

As operações da aplicação são organizadas em casos de uso específicos, evitando concentrar regras diretamente nos Controllers.

### Entity Framework Core

Utilizado para:

- Mapeamento objeto-relacional
- Consultas
- Persistência
- Relacionamentos
- Migrations

### FluentValidation

Utilizado para realizar validações dos dados recebidos pela aplicação.

---

# Estrutura resumida

```text
ProductCatalog-API/
│
├── ProductCatalog.API/
│   ├── Controllers/
│   ├── Extensions/
│   ├── Middleware/
│   └── Program.cs
│
├── ProductCatalog.Application/
│   ├── DTOs/
│   ├── Interfaces/
│   ├── UseCases/
│   ├── Validators/
│   └── Services/
│
├── ProductCatalog.Domain/
│   ├── Entities/
│   ├── Exceptions/
│   └── Interfaces/
│
├── ProductCatalog.Infrastructure/
│   ├── Configurations/
│   ├── Migrations/
│   ├── Persistence/
│   └── Repositories/
│
├── ProductCatalog.API.sln
└── README.md
```

---

# Próximos passos

O projeto está sendo desenvolvido como uma aplicação de treinamento. Algumas evoluções possíveis para versões futuras incluem:

- Implementação de testes automatizados
- CI/CD
- Melhorias no tratamento global de erros
- Autenticação e autorização
- Paginação
- Melhorias de documentação
- Docker
- Deploy da aplicação
- Melhorias de observabilidade e logging

---

# Autor

**Caio Egidio**

GitHub:  
https://github.com/CaioEgidio

LinkedIn:  
https://www.linkedin.com/in/caio-egidio-7481aa281/

---

## Licença

Projeto desenvolvido para fins de **estudo, aprendizado e portfólio**.
