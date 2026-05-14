namespace ProductCatalog.Application.DTOs;

public class CreateProductRequest
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
}

