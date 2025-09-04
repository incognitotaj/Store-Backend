using Store.Application.Abstractions.Messaging;

namespace Store.Application.Categories.Get;

public sealed class GetCategoryQuery : IQuery<List<CategoryResponse>>;