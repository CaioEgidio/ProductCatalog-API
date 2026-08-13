namespace ProductCatalog.Application.DTOs;

// DTO: dados recebidos para criar um produto
public class CreateProductRequest
{
    public string Nome { get; set; } = string.Empty; // começa a propriedade como texto vazio, em vez null
    public string Descricao { get; set; } = string.Empty;
    public decimal Preco { get; set; }
}

