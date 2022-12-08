using LibraryDataAccess;
using LibraryServices;

namespace LibraryEntities;

internal class Program
{
    private static void Main(string[] args)
    {
        var service = new Service(new Repository<Library>(), new Repository<Book>());

        service.Initialize();
        service.EntryInLibrary();

        Console.ReadKey();
    }
}