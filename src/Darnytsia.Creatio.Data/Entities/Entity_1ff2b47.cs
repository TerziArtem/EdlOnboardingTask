namespace Darnytsia.Creatio.Data.Entities;

public partial record Entity_1ff2b47 : BaseEntity
{
    public Guid? EdlBookId { get; set; }

    public Guid? EdlBookAuthorId { get; set; }

    public string? Name { get; set; }

    public override string ToString() => Name!;
}
