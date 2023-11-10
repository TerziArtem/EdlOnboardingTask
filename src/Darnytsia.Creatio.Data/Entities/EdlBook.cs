namespace Darnytsia.Creatio.Data.Entities;

public partial record EdlBook : BaseEntity
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public int PageCount { get; set; }

    public DateTime? PublishDate { get; set; }

    public Guid? BookStatusId { get; set; }

    public Guid? CoverTypeId { get; set; }

    public override string ToString() => Name!;
}
