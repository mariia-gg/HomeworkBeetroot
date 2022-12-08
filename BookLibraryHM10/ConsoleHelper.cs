using BookLibraryHM10.Models;
using LibraryServices.Models;
using LibraryEntities;
using LibraryServices.Validators;
using FluentValidation.Results;
using FluentValidation;

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

        Book book = new Book();

        //CustomerValidator validator = new CustomerValidator();

        //ValidationResult result = validator.Validate(customer);
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