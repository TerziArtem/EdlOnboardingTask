using Darnytsia.Creatio.Core.Features.Books.Commands;
using Edenlab.Creatio.Web.AspNet;
using MediatR;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace Darnytsia.Creatio.Api.Controllers;

[RoutePrefix("api/books")]
public class BooksController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public BooksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [Route("{bookId}")]
    [SwaggerResponse(HttpStatusCode.Accepted)]
    public async Task<IHttpActionResult> CreateBookAuthorsById([FromUri] Guid bookId)
    {
        await _mediator.Send(new CreateBookAuthorsByIdCommand(bookId));
        return Accepted();
    }
}
