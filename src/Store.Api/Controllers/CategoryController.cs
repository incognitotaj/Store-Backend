using Microsoft.AspNetCore.Mvc;
using Store.Api.Extensions;
using Store.Api.Infrastructure;
using Store.Application.Abstractions.Messaging;
using Store.Application.Categories.Create;
using Store.Application.Categories.Delete;
using Store.Application.Categories.Get;

namespace Store.Api.Controllers
{
    /// <summary>
    /// Categories API
    /// </summary>
    [Route("categories")]
    public class CategoryController : BaseApiController
    {
        private readonly IQueryHandler<GetCategoryQuery, List<CategoryResponse>> _getHandler;
        private readonly IQueryHandler<GetCategoryByIdQuery, CategoryResponse> _getByIdHandler;
        private readonly ICommandHandler<CreateCategoryCommand, Guid> _createHandler;
        private readonly ICommandHandler<DeleteCategoryCommand> _deleteHandler;

        /// <summary>
        /// Constructor for categories API
        /// </summary>
        /// <param name="getHandler"></param>
        /// <param name="getByIdHandler"></param>
        /// <param name="createHandler"></param>
        /// <param name="deleteHandler"></param>
        public CategoryController(
            IQueryHandler<GetCategoryQuery, List<CategoryResponse>> getHandler,
            IQueryHandler<GetCategoryByIdQuery, CategoryResponse> getByIdHandler,
            ICommandHandler<CreateCategoryCommand, Guid> createHandler,
            ICommandHandler<DeleteCategoryCommand> deleteHandler)
        {
            _getHandler = getHandler;
            _getByIdHandler = getByIdHandler;
            _createHandler = createHandler;
            _deleteHandler = deleteHandler;
        }

        /// <summary>Returns all categories</summary>
        /// <returns>The list of categories</returns>
        /// <response code="200">Returned the list of categories</response>
        [HttpGet]
        public async Task<IResult> Get(CancellationToken cancellationToken = default)
        {
            var query = new GetCategoryQuery();
            var result = await _getHandler.Handle(query, cancellationToken);
            return result.Match(Results.Ok, CustomResults.Problem);
        }

        /// <summary>Returns a specific category with ID</summary>
        /// <param name="id">The ID of the category to return</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>The category</returns>
        /// <response code="200">Returned the category</response>
        /// <response code="404">Returned when no category with the provided ID was found</response>
        [HttpGet("{id:guid}")]
        public async Task<IResult> GetById(Guid id, CancellationToken cancellationToken = default)
        {
            var query = new GetCategoryByIdQuery
            {
                Id = id
            };

            var result = await _getByIdHandler.Handle(query, cancellationToken);

            return result.Match(Results.Ok, CustomResults.Problem);
        }

        /// <summary>Creates a new category</summary>
        /// <param name="command">Data to create a new category</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>GUID of the created category</returns>
        /// <response code="201">Returned the GUID of the category created</response>
        /// <response code="400">Returned when the category can not be created with the provided model.</response>
        [HttpPost]        
        public async Task<IResult> Create([FromBody] CreateCategoryCommand command, CancellationToken cancellationToken = default)
        {
            var result = await _createHandler.Handle(command, cancellationToken);

            return result.Match(Results.Created, CustomResults.Problem);
        }

        /// <summary>Deletes an existing category</summary>
        /// <param name="id">ID of the category to delete</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>No content</returns>
        /// <response code="204">Returned when the category deleted successfully</response>
        /// <response code="404">Returned when no category with the provided ID was found</response>
        [HttpDelete("{id:guid}")]
        public async Task<IResult> Delete(Guid id, CancellationToken cancellationToken = default)
        {
            var command = new DeleteCategoryCommand { Id = id };
            var result = await _deleteHandler.Handle(command, cancellationToken);

            return result.Match(Results.NoContent, CustomResults.Problem);
        }

    }
}
