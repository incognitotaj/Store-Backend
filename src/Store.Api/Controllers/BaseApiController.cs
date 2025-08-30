using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Store.Infrastructure.Database;
using System.Net.Mime;

namespace Store.Api.Controllers
{
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public abstract class BaseApiController(ApiDbContext db) : ControllerBase
    {
        protected ApiDbContext Db { get; } = db;
    }
}
