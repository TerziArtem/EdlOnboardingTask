using Darnytsia.Creatio.Abstractions;
using Darnytsia.Creatio.Data.Entities;
using Edenlab.Creatio.Abstractions;
using Edenlab.Creatio.EF;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Darnytsia.Creatio.Infrastructure.Persistence;

public class DarnytsiaDbContext : DbContext, IDbContext
{
    public DarnytsiaDbContext(
        IServiceProvider serviceProvider,
        IUserContext userContext)
        : base(serviceProvider, userContext)
    {
    }

    public DbSet<Contact> Contacts => Set<Contact>();

    public DbSet<EdlBook> Books => Set<EdlBook>();

    public DbSet<Entity_1ff2b47> BookAuthors => Set<Entity_1ff2b47>();

    public override async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            await base.SaveChangesAsync(cancellationToken);
        }
        catch
        {
            ChangeTracker.Reset();
        }
    }
}
