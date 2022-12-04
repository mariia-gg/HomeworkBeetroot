using LibraryDataAccess;
using LibraryServices;

namespace LibraryEntities
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var service = new Service();
            service.Initialize();
            service.EntryInLibrary();

            Console.ReadKey();
        }
    }
}
