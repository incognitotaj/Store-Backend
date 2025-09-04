using Microsoft.EntityFrameworkCore;
using Shared;
using Store.Application.Abstractions.Data;
using Store.Application.Abstractions.Messaging;

namespace Store.Application.Categories.Get;

public sealed class GetCategoryQueryHandler(IApiDbContext context) : IQueryHandler<GetCategoryQuery, List<CategoryResponse>>
{
    public async Task<Result<List<CategoryResponse>>> Handle(GetCategoryQuery query, CancellationToken cancellationToken)
    {
        var categories = await context.Categories.ToListAsync();

        var result = categories.Select(p => new CategoryResponse
        {
            Id = p.Id,
            Name = p.Name,
            Description = p.Description,
        }).ToList();

        return result;
    }
}
