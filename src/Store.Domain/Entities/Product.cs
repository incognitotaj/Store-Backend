using Store.Domain.Primitives;

namespace Store.Domain.Entities;

public class Product : Entity
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public Guid CategoryId { get; private set; }
    
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
    }
}
