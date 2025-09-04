using Microsoft.EntityFrameworkCore;
using Shared;
using Store.Application.Abstractions.Data;
using Store.Application.Abstractions.Messaging;
using Store.Application.Categories.Get;

namespace Store.Application.Categories.GetById;

public sealed class GetCategoryByIdQueryHandler(IApiDbContext context) : IQueryHandler<GetCategoryByIdQuery, CategoryResponse>
{
    public async Task<Result<CategoryResponse>> Handle(GetCategoryByIdQuery query, CancellationToken cancellationToken)
    {
        var category = await context.Categories.FirstOrDefaultAsync(p => p.Id == query.Id);

        if (category == null)
        {
            return Result.Failure<CategoryResponse>(new Error(
                code: "Category.NotFound",
                description: "Category not found",
                ErrorType.NotFound));
        }

        var result = new CategoryResponse
        {
            Id = category.Id,
            Name = category.Name,
            Description = category.Description,
        };

        return result;
    }
}
