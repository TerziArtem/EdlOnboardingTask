using Darnytsia.Creatio.Abstractions;
using Darnytsia.Creatio.Core.Features.Contacts.Commands;
using System.Linq;
using System.Threading;

namespace Darnytsia.Creatio.Core.Features.Contacts.Handlers;

public class UpdateContactBirthdayDateByIdHandler : IRequestHandler<UpdateContactBirthdayDateByIdCommand>
{
    private readonly IDbContext _dbContext;

    public UpdateContactBirthdayDateByIdHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(UpdateContactBirthdayDateByIdCommand request, CancellationToken cancellationToken)
    {
        var contact = await _dbContext.Contacts.FindAsync(request.ContactId, cancellationToken: cancellationToken);
        contact!.BirthDate = request.ContactBirthdate;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
