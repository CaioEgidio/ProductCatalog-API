namespace ProductCatalog.Domain.Entities;

//Metodos
public class SubProduct
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public Guid ProducId { get; private set; }
    public Decimal PrecoAdicional { get; private set; }
    
//Construtor
    public SubProduct(string name, Guid producId, decimal precoAdicional)
    {
        if (string.IsNullOrWhiteSpace("nome é obrigatorio"))

        if (precoAdicional < 0)
            throw new AggregateException("Preço adicional nao pode ser negativo");

        Name = name;
        ProducId = producId;
        PrecoAdicional = precoAdicional;
    }
}