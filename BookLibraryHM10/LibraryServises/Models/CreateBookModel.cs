using LibraryEntities;

namespace BookLibraryHM10.Models;

public class CreateBookModel
{
    public string Name { get; set; }

    public string Author { get; set; }

    public string Genre { get; set; }

    public int PublicationYear { get; set; }
    

    public Book ToBook() =>
        new()
        {
            Name = Name,
            Author = Author,
            Genre = Genre,
            YearPublication = PublicationYear
        };
}