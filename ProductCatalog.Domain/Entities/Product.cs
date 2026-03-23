namespace ProductCatalog.Domain.Entities;

public class Product
{
    // Propriedades 
    public Guid Id { get; private set; }
    public string NomeDoProduto { get; private set; }
    public string Descrição { get; private set; }
    public decimal Preco { get; private set; }
    public Guid CompradorId { get; private set; }
    public DateTime DataCadastro { get; private set; }
    
    // Construtor e Regras 
    public Product(string nomeDoProduto, string descrição, decimal preco, Guid compradorId)
    {
        if (string.IsNullOrWhiteSpace(nomeDoProduto))
        {
            throw new ArgumentException("Nome do produto é obrigatorio!");
        }

        if (preco <= 0)
        {
            throw new ArgumentException("Valor tem que ser maior que 0.");
        }

        if (compradorId == Guid.Empty)
        {
            throw new ArgumentException("comprador não pode ter id vazio");
        }

        Id = Guid.NewGuid();
        NomeDoProduto = nomeDoProduto;
        Descrição = descrição;
        Preco = preco;
        CompradorId = compradorId;
        DataCadastro = DateTime.UtcNow;
    }
}