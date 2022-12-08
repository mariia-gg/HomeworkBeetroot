namespace LibraryEntities;

public class Book : BaseEntity, IEntity
{
    public string? Name { get; set; }

    public string? Author { get; set; }

    public string? Genre { get; set; }

    public int? YearPublication { get; set; }

    public int LibraryId { get; set; }
}