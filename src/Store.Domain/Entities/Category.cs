using Store.Domain.Primitives;
using System.Xml.Linq;

namespace Store.Domain.Entities;

public class Category : Entity
{
    public string Name { get; private set; }
    public string Description { get; private set; }

    private Category(Guid id, string name, string description) : base(id)
    {
        Name = name;
        Description = description;
    }

    private Category()
    {
        this.Name = default!;
        this.Description = default!;
    }

    public static Category Create(Guid id, string name, string description)
    {
        return new Category(id, name, description);
    }
}
