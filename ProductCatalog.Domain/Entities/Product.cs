namespace ProductCatalog.Domain.Entities;

public class Product
{
    //Propriedades 
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Descricao { get; private set; }
    public decimal Preco { get; private set; }
    public Guid UserId { get; private set; }
    public DateTime DataCriacao { get; private set; }
    
    //Construtor
    public Product(string nome, string descricao, decimal preco, Guid userId)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new AbandonedMutexException("Nome é obrigatorio");
        
        if (preco <= 0)
            throw new ArgumentException("Preço deve ser maior que 0.");

        Id = Guid.NewGuid();
        Nome = nome;
        Descricao = descricao;
        Preco = preco;
        UserId = userId;
        DataCriacao = DateTime.UtcNow;

    }
}


//Postgree usa timestamp with time zone