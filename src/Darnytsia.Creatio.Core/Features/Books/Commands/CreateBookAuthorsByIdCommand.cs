using System;

namespace Darnytsia.Creatio.Core.Features.Books.Commands;

public record CreateBookAuthorsByIdCommand(Guid BookId) : IRequest;
