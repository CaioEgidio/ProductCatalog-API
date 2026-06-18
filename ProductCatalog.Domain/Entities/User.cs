namespace ProductCatalog.Domain.Entities;

public class User
{
    // Atributos da classe / encapsulamento 
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string Email { get; private set; }
    public DateTime DataCriacao { get; private set; }
    
    // Construtor
    public User(string nome, string email)
    {
        if (string.IsNullOrEmpty(nome))
            throw new AbandonedMutexException("O nome é obrigatario");
        
        Id = Guid.NewGuid();
        Nome = nome;
        Email = email;
        DataCriacao = DateTime.UtcNow;
    }
    
    
}
// utilizo encapsulamento, permito new product.id mas impesso product.id fora da classe 