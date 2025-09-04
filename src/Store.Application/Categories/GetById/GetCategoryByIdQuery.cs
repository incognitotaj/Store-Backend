using Store.Application.Abstractions.Messaging;

namespace Store.Application.Categories.Get;

public sealed class GetCategoryByIdQuery : IQuery<CategoryResponse>
{
    public Guid Id { get; init; }
}