namespace ProductCatalog.Application.DTOs;

// DTO: dados recebidos para criar um produto
public class CreateProductRequest
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
}

