namespace ProductCatalog.Domain.Entities;

public class SubProduct
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public Guid ProductId { get; private set; }
    public decimal PrecoAdicional { get; private set; }

    //Construtor
    public SubProduct(Guid id, string nome, Guid productId, decimal precoAcional)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome do subproduto é obrigatório.");
        
        if (ProductId == Guid.Empty)
            throw new ArgumentException("O subproduto deve pertencer a um produto válido.");
        
        if (precoAcional < 0)
            throw new ArgumentException("O preço adicional não pode ser negativo.");
        
        Id = Guid.NewGuid(); // gerador de id 
        Nome = nome;
        ProductId = productId;
        PrecoAdicional = precoAcional;
    }

}