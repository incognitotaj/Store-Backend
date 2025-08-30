using Store.Domain.Abstractions;

namespace Store.Domain.Primitives;

public abstract class Entity
{
    protected Entity(Guid id) => Id = id;
    
    protected Entity() { }

    public Guid Id { get; protected set; }

    public List<IDomainEvent> DomainEvents => [.. _domainEvents];

    private readonly List<IDomainEvent> _domainEvents = [];

    public void Clear()
    {
        _domainEvents.Clear();
    }

    public void Raise(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
}
