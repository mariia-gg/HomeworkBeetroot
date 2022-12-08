using BookLibraryHM10.Models;
using LibraryServises.Models;

namespace BookLibraryHM10;

public static class ConsoleHelper
{
    public static CreateBookModel ReadBook()
    {
        Console.WriteLine("Enter book name:");
        var name = Console.ReadLine();

        Console.WriteLine("Enter book author:");
        var author = Console.ReadLine();

        Console.WriteLine("Enter book genre:");
        var genre = Console.ReadLine();

        Console.WriteLine("Enter book publication year:");
        var publicationYear = int.Parse(Console.ReadLine());

        return new CreateBookModel
        {
            Name = name,
            Author = author,
            Genre = genre,
            PublicationYear = publicationYear
        };
    }

    public static CreateLibraryModel ReadLibrary()
    {
        Console.WriteLine("Enter library name:");
        var name = Console.ReadLine();

        return new CreateLibraryModel
        {
            Name = name
        };
    }

    public static int GetLibraryId()
    {
        Console.WriteLine("Enter library id:");
        var id = int.Parse(Console.ReadLine());

        return id;
    }
}