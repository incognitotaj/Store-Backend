using Store.Domain.Primitives;

namespace Store.Domain.Entities;

public class Category : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    public Category(Guid id, string name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }

    private Category()
    {
        this.Name = default!;
        this.Description = default!;
    }
}
