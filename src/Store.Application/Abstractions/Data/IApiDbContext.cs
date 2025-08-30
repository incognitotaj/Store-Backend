using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;

namespace Store.Application.Abstractions.Data;

public interface IApiDbContext
{
    DbSet<Category> Categories { get; }
    DbSet<Product> Products { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
