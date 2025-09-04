using Shared;
using Store.Application.Abstractions.Data;
using Store.Application.Abstractions.Messaging;

namespace Store.Application.Categories.Delete;

public class DeleteCategoryCommandHandler(IApiDbContext context) : ICommandHandler<DeleteCategoryCommand>
{
    public async Task<Result> Handle(DeleteCategoryCommand command, CancellationToken cancellationToken)
    {
        var category = context.Categories.FirstOrDefault(p => p.Id == command.Id);

        if (category == null)
        {
            return Result.Failure(Error.NotFound("Category.NotFound", "Category not found"));
        }

        context.Categories.Remove(category);
        await context.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
