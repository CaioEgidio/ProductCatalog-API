namespace ProductCatalog.Domain.Entities;

//Metodos
public class SubProduct
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Guid ProductId { get; private set; }
    public Decimal PrecoAdicional { get; private set; }
    
//Construtor
    public SubProduct(string name, Guid productId, decimal precoAdicional)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("nome é obrigatorio");

        if (precoAdicional < 0)
            throw new ArgumentException("Preço adicional nao pode ser negativo");

        Name = name;
        ProductId = productId;
        PrecoAdicional = precoAdicional;
    }
}

