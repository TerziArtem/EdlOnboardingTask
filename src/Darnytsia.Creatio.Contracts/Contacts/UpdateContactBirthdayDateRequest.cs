using System;

namespace Darnytsia.Creatio.Contracts.Contacts;

public record UpdateContactBirthdayDateRequest
{
    public DateTime BirthdayDate { get; set; }
}
