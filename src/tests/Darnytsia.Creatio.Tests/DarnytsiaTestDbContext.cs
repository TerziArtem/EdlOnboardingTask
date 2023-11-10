using Darnytsia.Creatio.Abstractions;
using Darnytsia.Creatio.Data.Entities;
using Edenlab.Creatio.EF;
using Edenlab.Creatio.EF.InMemory;

namespace Darnytsia.Creatio.Tests;

public class DarnytsiaTestDbContext : InMemoryDbContext, IDbContext
{
    public DbSet<Contact> Contacts { get; }

    public DbSet<EdlBook> Books { get; }
    
    public DbSet<Entity_1ff2b47> BookAuthors { get; }

}
