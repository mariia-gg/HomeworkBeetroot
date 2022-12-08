using LibraryServices;
using LibraryServices.Validators;
using FluentValidation.Results;

namespace BookLibraryHM10;

internal class Application
{
    private readonly ILibraryService _libraryService;

    public Application(ILibraryService libraryService) =>
        _libraryService = libraryService;

    public void Run()
    {
        do
        {
            Console.WriteLine(
                "Choose operation (-lib_c)- create library, (-lib_list) - list of created libraries, (-book_c)- create book, (-book_list) - information about books in one of libraries, (-exit) - exit ");

            var input = Console.ReadLine();

            HandleInput(input);
        } while (true);
    }

    private void HandleInput(string input)
    {
        switch (input)
        {
            case "-lib_c":
                HandleCreateLibraryCommand();

                break;
            case "-lib_list":
                HandleLibraryListCommand();

                break;
            case "-book_c":
                HandleCreateBookCommand();

                break;
            case "-book_list":
                HandleBookListCommand();

                break;

            case "-exit":
                return;
        }
    }

    private void HandleBookListCommand()
    {
        var libraryId = ConsoleHelper.GetLibraryId();

        _libraryService.PrintBooks(libraryId);
    }

    private void HandleCreateBookCommand()
    {
        var createBookModel = ConsoleHelper.ReadBook();

        _libraryService.CreateBook(createBookModel);
    }

    private void HandleLibraryListCommand()
    {
        _libraryService.PrintLibraries();
    }

    private void HandleCreateLibraryCommand()
    {
        var createLibraryModel = ConsoleHelper.ReadLibrary();

        _libraryService.CreateLibrary(createLibraryModel);

        CreateLibraryModelValidator validator = new CreateLibraryModelValidator();

        ValidationResult results = validator.Validate(createLibraryModel);

        if (!results.IsValid)
        {
            foreach (var failure in results.Errors)
            {
                Console.WriteLine("Property " + failure.PropertyName + " failed validation. Error was: " + failure.ErrorMessage);
            }
        }
    }
}