using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Store.Domain.Entities;
using Store.Infrastructure.Database;

namespace Store.Api.Controllers.Products;

[Route("products")]
public class ProductController(ApiDbContext db) : BaseApiController(db)
{
    /// <summary>Returns all products</summary>
    /// <returns>The list of products</returns>
    /// <response code="200">Returns the list of products</response>
    [HttpGet]
    public async Task<Ok<List<Product>>> Get()
    {
        var result = await this.Db.Products.ToListAsync();
        return TypedResults.Ok(result);
    }

    /// <summary>Returns a specific product with ID</summary>
    /// <param name="id">The ID of the product to return</param>
    /// <returns>The product</returns>
    /// <response code="200">Returns the product</response>
    /// <response code="404">Returns when no product with the provided ID was found</response>
    [HttpGet("{id:guid}")]
    public async Task<Results<NotFound, Ok<Product>>> GetById(Guid id)
    {
        var result = await this.Db.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (result == null)
        {
            return TypedResults.NotFound();
        }

        return TypedResults.Ok(result);
    }
}
