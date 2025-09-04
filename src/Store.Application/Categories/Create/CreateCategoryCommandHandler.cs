using Shared;
using Store.Application.Abstractions.Data;
using Store.Application.Abstractions.Messaging;
using Store.Domain.Entities;

namespace Store.Application.Categories.Create;

public class CreateCategoryCommandHandler(IApiDbContext context) : ICommandHandler<CreateCategoryCommand, Guid>
{
    public async Task<Result<Guid>> Handle(CreateCategoryCommand command, CancellationToken cancellationToken)
    {
        if (command == null)
        {
            return Result.Failure<Guid>(Error.NullValue);
        }

        var category = Category.Create(Guid.NewGuid(), command.Name, command.Description);

        await context.Categories.AddAsync(category, cancellationToken);
        await context.SaveChangesAsync(cancellationToken);

        return category.Id;
    }
}
