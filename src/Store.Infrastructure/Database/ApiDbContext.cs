using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Store.Application.Abstractions.Data;
using Store.Domain.Abstractions;
using Store.Domain.Entities;
using Store.Domain.Primitives;
namespace Store.Infrastructure.Database;

public sealed class ApiDbContext(
    //IDomainEventsDispatcher domainEventsDispatcher,
    DbContextOptions<ApiDbContext> options)
    : DbContext(options), IApiDbContext
{
    public DbSet<Category> Categories { get; set; }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApiDbContext).Assembly);
        //modelBuilder.HasDefaultSchema(apiDbContextOptions.Value.DefaultSchema);
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        // When should you publish domain events?
        //
        // 1. BEFORE calling SaveChangesAsync
        //     - domain events are part of the same transaction
        //     - immediate consistency
        // 2. AFTER calling SaveChangesAsync
        //     - domain events are a separate transaction
        //     - eventual consistency
        //     - handlers can fail

        await ProcessDomainEventsAsync();
        return await base.SaveChangesAsync(cancellationToken);
    }

    private async Task ProcessDomainEventsAsync()
    {
        var domainEvents = ChangeTracker
            .Entries<Entity>()
            .Select(e => e.Entity)
            .SelectMany(entity =>
            {
                List<IDomainEvent> domainEvents = entity.DomainEvents;
                entity.Clear();

                return domainEvents;
            }).ToList();

        await Task.CompletedTask; // domainEventsDispatcher.DispatchAsync(domainEvents);
    }
}
