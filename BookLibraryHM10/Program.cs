using BookLibraryHM10;
using LibraryDataAccess;
using LibraryServices;

namespace LibraryEntities;

internal class Program
{
    private static void Main(string[] args)
    {
        new Application(new LibraryService(new  Repository<Library>(), new Repository<Book>())).Run();
    }
}