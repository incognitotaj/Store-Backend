using Store.Domain.Primitives;
using System.Diagnostics;
using System.Xml.Linq;

namespace Store.Domain.Entities;

public class Product : Entity
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public Guid CategoryId { get; private set; }
    public virtual Category? Category { get; set; }

    public Product(Guid id, string name, decimal price, Guid categoryId) : base(id)
    {
        Name = name;
        Price = price;
        CategoryId = categoryId;
    }

    private Product() 
    {
        this.Name = default!;
        this.Price = default!;
        this.CategoryId = default!;

        this.Category = default!;
    }
}
