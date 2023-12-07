using System;

namespace Darnytsia.Creatio.Contracts.Books;

public record CreateBookAuthorsByIdRequest
{
    public Guid EdlBookId { get; set; }
    public Guid EdlBookAuthorId { get; set; }
}
