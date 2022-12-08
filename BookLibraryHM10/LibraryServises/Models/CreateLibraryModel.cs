using LibraryEntities;

namespace LibraryServises.Models;

public class CreateLibraryModel
{
    public string Name { get; set; }

    public Library ToLibrary() =>
        new()
        {
            Name = Name
        };
}