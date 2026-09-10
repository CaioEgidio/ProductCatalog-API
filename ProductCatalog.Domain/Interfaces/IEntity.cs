namespace ProductCatalog.Domain.Interfaces;

// Interface básica para identificar uma entidade do domínio.
public interface IEntity
{
    Guid Id { get; }
}