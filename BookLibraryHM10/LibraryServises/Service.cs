using LibraryDataAccess;
using LibraryEntities;

namespace LibraryServices
{
    public class Service
    {
        private readonly Repository<LibraryEntity> _library;
        private readonly Repository<BookEntity> _book;

        public Service()
        {
            _library = new Repository<LibraryEntity>();
            _book = new Repository<BookEntity>();
        }

        public void Initialize()
        {
            if (_book.GetAll().Any()) return;

            CreateLibrary();
            CreateBook();
        }

        public void EntryInLibrary()
        {
            do
            {
                Console.WriteLine("Choose operation (-lib_c)- create library, (-lib_list) - list of created libraries, (-book_c)- create book, (-book_list) - information about books in one of libraries");
                var input = Console.ReadLine();
                

                switch (input)
                {
                    case "-lib_c":
                        CreateLibrary();
                        break;
                    case "-lib_list":
                        PrintLibraries();
                        break;
                    case "-book_c":
                        CreateBook(); 
                        break;
                    case "-book_list":
                        PrintBooks(); 
                        break;
                        goto Exit;
                    default:
                        continue;
                }
            } while (true);
        
        Exit:;

        }

        public void CreateLibrary()
        {
            Console.WriteLine("Please enter Name of Library:  "); 
            var libraryCreate = new LibraryEntity
            { 
                Name = Console.ReadLine() 
            };

            _library.Insert(libraryCreate);
        }

        public void CreateBook()
        {
            Console.WriteLine(" Please enter information about book () "); 
            var library = ChooseLib();

            var BookInformation = new BookEntity
            {
                LibraryId = library.Id,
                BookName = Console.ReadLine(),
                BookAuthor = Console.ReadLine(),
                BookGenre = Console.ReadLine(),
                YearPublication = int.Parse(Console.ReadLine()) 
            }; 

            _book.Insert(BookInformation);  
        }

        public void PrintLibraries()
        {
            var libraries = _library.GetAll();

            foreach (var library in libraries)
            {
                Console.WriteLine($"Library Id :{library.Id}, Library name: {library.Name}");
            }
        }

        public void PrintBooks()
        {
            var books = _book.GetAll();

            var library = ChooseLib();

            foreach (var book in books )
            {
              Console.WriteLine($"Library Id: {library.Id}\n Name of book : {book.BookName}\n Author of book: {book.BookAuthor}\n Genre of book: {book.BookGenre}\n Year of book: {book.YearPublication}");
            }
        }

        private LibraryEntity ChooseLib()
        {
            Console.WriteLine("Choose Library Id: ");

            foreach (var library in _library.GetAll())
            {
                Console.WriteLine($"Library Id: {library.Id}, Library name: {library.Name}");
            }

            return _library.Get(int.Parse(Console.ReadLine()));

            Console.Clear();
        } 

        
    }
}
