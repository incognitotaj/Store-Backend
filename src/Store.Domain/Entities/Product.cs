using Store.Domain.Primitives;

namespace Store.Domain.Entities;

public class Product : Entity
{
    public string Name { get; private set; }
    public decimal Price { get; private set; }

    public Guid CategoryId { get; private set; }
    
    private Product(Guid id, string name, decimal price, Guid categoryId) : base(id)
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

    public static Product Create(Guid id, string name, decimal price, Guid categoryId)
    {
        return new Product(id, name, price, categoryId);
    }
}
