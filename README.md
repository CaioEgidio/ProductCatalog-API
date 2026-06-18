# 🚀 ProductCatalog API

Uma API REST desenvolvida com **ASP.NET Core** para gerenciamento de produtos, aplicando conceitos de **Clean Architecture**, **Entity Framework Core**, **Repository Pattern** e boas práticas de desenvolvimento backend.

## 📖 Sobre o Projeto

O ProductCatalog API foi criado com o objetivo de servir como projeto de estudo e portfólio, demonstrando a construção de uma API moderna utilizando tecnologias amplamente adotadas pelo mercado.

A aplicação permite operações completas de gerenciamento de produtos, seguindo os princípios de separação de responsabilidades e arquitetura em camadas.

---

## 🛠️ Tecnologias Utilizadas

* ASP.NET Core
* C#
* Entity Framework Core
* SQL Server
* Swagger / OpenAPI
* Dependency Injection
* Repository Pattern
* Clean Architecture
* REST API

---

## 📂 Estrutura do Projeto

```text
ProductCatalog.API
│
├── ProductCatalog.API             # Camada de apresentação
├── ProductCatalog.Application     # Regras de negócio
├── ProductCatalog.Domain          # Entidades e contratos
├── ProductCatalog.Infrastructure  # Persistência e acesso a dados
```

---

## ✨ Funcionalidades

* ✅ Cadastro de produtos
* ✅ Listagem de produtos
* ✅ Consulta por ID
* ✅ Atualização de produtos
* ✅ Remoção de produtos
* ✅ Persistência em banco de dados SQL Server
* ✅ Documentação automática com Swagger

---

## ⚙️ Configuração do Projeto

### 1. Clone o repositório

```bash
git clone https://github.com/CaioEgidio/ProductCatalog-API.git
```

### 2. Acesse a pasta

```bash
cd ProductCatalog-API
```

### 3. Configure a Connection String

No arquivo:

```json
appsettings.json
```

Configure sua conexão com o SQL Server:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=ProductCatalogDb;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

---

## 🗄️ Aplicando as Migrations

Execute os comandos:

```bash
dotnet ef database update \
--project ProductCatalog.Infrastructure \
--startup-project ProductCatalog.API
```

---

## ▶️ Executando a Aplicação

```bash
dotnet run --project ProductCatalog.API
```

---

## 📚 Swagger

Após iniciar a aplicação, acesse:

```text
https://localhost:xxxx/swagger
```

ou

```text
http://localhost:xxxx/swagger
```

A documentação interativa da API será exibida automaticamente.

---

## 📌 Exemplo de Produto

```json
{
  "id": 1,
  "nome": "Notebook Gamer",
  "descricao": "RTX 4050 e Ryzen 7",
  "preco": 5999.99
}
```

---

## 🎯 Objetivos do Projeto

Este projeto foi desenvolvido para:

* Praticar desenvolvimento backend com .NET
* Aprender Entity Framework Core
* Aplicar Clean Architecture
* Trabalhar com migrations e banco de dados
* Construir portfólio para oportunidades de estágio e desenvolvimento profissional

---

## 👨‍💻 Autor

Caio Egídio

GitHub:
https://github.com/CaioEgidio

LinkedIn:
(Adicionar seu LinkedIn aqui)

---

## 📄 Licença

Este projeto está disponível para fins de estudo e aprendizado.
