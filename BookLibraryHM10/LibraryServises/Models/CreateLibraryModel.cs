using LibraryEntities;

namespace LibraryServices.Models;

public class CreateLibraryModel
{
    public string Name { get; set; }

    public Library ToLibrary() =>
        new()
        {
            Name = Name
        };
} 
