using Darnytsia.Creatio.Abstractions;
using Darnytsia.Creatio.Core.Features.Books.Commands;
using Darnytsia.Creatio.Data;
using Darnytsia.Creatio.Data.Entities;
using System.Linq;
using System.Threading;

namespace Darnytsia.Creatio.Core.Features.Books.Handlers;

public class CreateBookAuthorsByIdHandler : IRequestHandler<CreateBookAuthorsByIdCommand>
{
    private readonly IDbContext _dbContext;

    public CreateBookAuthorsByIdHandler(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Unit> Handle(CreateBookAuthorsByIdCommand request, CancellationToken cancellationToken)
    {
        var customers = await _dbContext.Contacts.AsNoTracking()
            .Where(contact => contact.TypeId == DbConst.Contact.Type.Customer)
            .ToListAsync(cancellationToken: cancellationToken);

        foreach (var contact in customers)
        {
            _dbContext.BookAuthors.Add(new Entity_1ff2b47()
            {
                EdlBookId = request.BookId, EdlBookAuthorId = contact.Id
            });
        }

        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
