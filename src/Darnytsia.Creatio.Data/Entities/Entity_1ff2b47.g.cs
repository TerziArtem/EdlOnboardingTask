#nullable enable
namespace Darnytsia.Creatio.Data.Entities;

public partial record Entity_1ff2b47
{
    private EdlBook? _edlBook;
    private Contact? _edlBookAuthor;

    public EdlBook? EdlBook
    {
        get => _edlBook;
        set
        {
            ChangedLinked.Value.Add(value!);
            EdlBookId = value!.Id;
            _edlBook = value;
        }
    }
    public Contact? EdlBookAuthor
    {
        get => _edlBookAuthor;
        set
        {
            ChangedLinked.Value.Add(value!);
            EdlBookAuthorId = value!.Id;
            _edlBookAuthor = value;
        }
    }
}
#nullable disable
