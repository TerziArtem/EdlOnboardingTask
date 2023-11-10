#nullable enable
namespace Darnytsia.Creatio.Data.Entities;

public partial record EdlBook
{
    private EdlBookStatus? _bookStatus;
    private EdlBookCoverType? _coverType;

    public EdlBookStatus? BookStatus
    {
        get => _bookStatus;
        set
        {
            ChangedLinked.Value.Add(value!);
            BookStatusId = value!.Id;
            _bookStatus = value;
        }
    }
    public EdlBookCoverType? CoverType
    {
        get => _coverType;
        set
        {
            ChangedLinked.Value.Add(value!);
            CoverTypeId = value!.Id;
            _coverType = value;
        }
    }
}
#nullable disable
