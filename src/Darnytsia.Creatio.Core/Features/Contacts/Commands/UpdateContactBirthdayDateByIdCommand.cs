using System;

namespace Darnytsia.Creatio.Core.Features.Contacts.Commands;

public record UpdateContactBirthdayDateByIdCommand(Guid ContactId, DateTime ContactBirthdate) : IRequest;
