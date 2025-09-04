using Store.Application.Abstractions.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Categories.Delete;

public class DeleteCategoryCommand : ICommand
{
    public Guid Id { get; init; }
}
