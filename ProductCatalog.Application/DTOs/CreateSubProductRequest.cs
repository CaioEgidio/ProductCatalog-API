namespace ProductCatalog.Application.DTOs;

public class CreateSubProductRequest
{
    public string Name  { get; set; }
    public Guid  ProductId  { get; set; }
    public decimal PrecoAdicional { get; set; }
}

