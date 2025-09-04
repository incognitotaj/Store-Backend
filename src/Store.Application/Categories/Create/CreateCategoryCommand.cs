using Store.Application.Abstractions.Messaging;
using Store.Application.Categories.Get;

namespace Store.Application.Categories.Create;

public class CreateCategoryCommand : ICommand<Guid>
{
    public string Name { get; init; }
    public string Description { get; init; }
}
