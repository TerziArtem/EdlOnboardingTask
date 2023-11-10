﻿using Darnytsia.Creatio.Abstractions;
using Darnytsia.Creatio.Core.Features.Contacts.Queries;
using Edenlab.Creatio.Abstractions.Services;
using System.Linq;
using System.Threading;

namespace Darnytsia.Creatio.Core.Features.Contacts.Handlers;

public class GetContactBirthdayDateByIdHandler : IRequestHandler<GetContactBirthdayDateByIdQuery, string>
{
    private readonly IDbContext _dbContext;
    private readonly ILocalizationStorage _localizationStorage;

    public GetContactBirthdayDateByIdHandler(IDbContext dbContext, ILocalizationStorage localizationStorage)
    {
        _dbContext = dbContext;
        _localizationStorage = localizationStorage;
    }

    public async Task<string> Handle(GetContactBirthdayDateByIdQuery request, CancellationToken cancellationToken)
    {
        var message = _localizationStorage.Get("contacts.birth-day-message");
        var contactBirthDate = (await _dbContext.Contacts.FindAsync(request.ContactId))!.BirthDate!;

        return string.Format(message, contactBirthDate.Value.Year.ToString(), contactBirthDate.Value.Month.ToString(), contactBirthDate.Value.Day.ToString());
    }
}
