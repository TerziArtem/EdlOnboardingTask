using System;

namespace Darnytsia.Creatio.Core.Features.Contacts.Queries;

public record GetContactBirthdayDateByIdQuery(Guid ContactId) : IRequest<string>;
