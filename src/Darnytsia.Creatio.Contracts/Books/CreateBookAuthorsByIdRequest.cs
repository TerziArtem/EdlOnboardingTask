using System;

namespace Darnytsia.Creatio.Contracts.Books;

public class CreateBookAuthorsByIdRequest
{
    public Guid EdlBookId { get; set; }
    public Guid EdlBookAuthorId { get; set; }
}
