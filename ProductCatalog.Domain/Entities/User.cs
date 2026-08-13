namespace ProductCatalog.Domain.Entities;

public class User
{
    // Atributos da classe / encapsulamento 
    public Guid Id { get; private set; }
    public string Nome { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public DateTime DataCriacao { get; private set; }
    
    //Usado pelo Entity Framework
    private User()
    {
        
    }
    
    // Construtor
    public User(string nome, string email)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome é obrigatario");

        if (string.IsNullOrEmpty(email))
        {
            throw new ArgumentException("O email é obrigatorio.");
        }
        
        Id = Guid.NewGuid();
        Nome = nome;
        Email = email;
        DataCriacao = DateTime.UtcNow;
    }
    
    
}
// utilizo encapsulamento, permito new product.id mas impesso product.id fora da classe 