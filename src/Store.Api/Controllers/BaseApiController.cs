using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace Store.Api.Controllers
{
    [ApiController]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    public abstract class BaseApiController
    {
    }
}
