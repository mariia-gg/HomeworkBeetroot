using BookLibraryHM10.Models;
using LibraryDataAccess;
using LibraryEntities;
using LibraryServices;
using LibraryServices.Models;

namespace LibraryServices;

public class LibraryService : ILibraryService
{
    private readonly IRepository<Library> _library;

    private readonly IRepository<Book> _book;

    public LibraryService(IRepository<Library> library, IRepository<Book> book)
    {
        _library = library;
        _book = book;
    }

    public void CreateLibrary(CreateLibraryModel createLibraryModel)
    {
        _library.Insert(createLibraryModel.ToLibrary());
    }

    public void CreateBook(CreateBookModel createBookModel)
    {
        var library = ChooseLibrary(GetLibraryId());

        var book = createBookModel.ToBook();

        book.LibraryId = library.Id;

        _book.Insert(book);
    }

    public void PrintLibraries()
    {
        foreach (var library in _library.GetAll())
        {
            Console.WriteLine($"Library Id :{library.Id}, Library name: {library.Name}");
        }
    }

    public void PrintBooks(int libraryId)
    {
        var books = _book.GetAll().Where(book => book.LibraryId == libraryId);

        if (!books.Any())
        {
            Console.WriteLine("There are no books in this library");

            return;
        }

        foreach (var book in books)
        {
            Console.WriteLine(
                $"Library Id: {libraryId}\n Name of book : {book.Name}\n Author of book: {book.Author}\n Genre of book: {book.Genre}\n Year of book: {book.YearPublication}");
        }
    }

    private Library? ChooseLibrary(int libraryId) => _library.Get(libraryId);

    private int GetLibraryId()
    {
        Console.WriteLine("Choose Library Id: ");

        foreach (var library in _library.GetAll())
        {
            Console.WriteLine($"Library Id: {library.Id}, Library name: {library.Name}");
        }

        var libraryId = int.Parse(Console.ReadLine() ?? string.Empty);

        return libraryId;
    }
}