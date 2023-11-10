using Darnytsia.Creatio.Contracts.Contacts;
using Darnytsia.Creatio.Core.Features.Contacts.Commands;
using Darnytsia.Creatio.Core.Features.Contacts.Queries;
using Edenlab.Creatio.Web.AspNet;
using MediatR;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;

namespace Darnytsia.Creatio.Api.Controllers;

[RoutePrefix("api/contacts")]
public class ContactsController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public ContactsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("{contactId}")]
    [SwaggerResponse(HttpStatusCode.OK)]
    public async Task<IHttpActionResult> GetByIdAsync([FromUri] Guid contactId)
    {
        return Ok(await _mediator.Send(new GetContactBirthdayDateByIdQuery(contactId)));
    }

    [HttpPost]
    [Route("{contactId}")]
    [SwaggerResponse(HttpStatusCode.Accepted, Type = typeof(UpdateContactBirthdayDateRequest))]
    public async Task<IHttpActionResult> UpdateBirthdayDateAsync([FromUri] Guid contactId, [FromBody] UpdateContactBirthdayDateRequest contact)
    {
        await _mediator.Send(new UpdateContactBirthdayDateByIdCommand(contactId, contact.BirthdayDate));
        return Accepted();
    }
}
