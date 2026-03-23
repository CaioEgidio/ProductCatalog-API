namespace ProductCatalog.Domain.Entities;

public class User
{
   // Propriedades 
   public Guid Id { get; private set; }
   public string Nome { get; private set; } 
   public string Email { get; private set; }
   public DateTime DataCriacao { get; private set; }
   
   // Construtor
   public User(string nome, string email)
   {
      if (string.IsNullOrWhiteSpace(nome))
      {
         throw new ArgumentException("O Nome é Obrigatorio!");
      }

      if (string.IsNullOrWhiteSpace(email))
      {
         throw new ArgumentException("O email é Obrigatorio!");
      }
      
      Id = Guid.NewGuid();
      Nome = nome;
      Email = email;
      DataCriacao = DateTime.UtcNow; 
   }
}
