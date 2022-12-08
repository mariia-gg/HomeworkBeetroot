using BookLibraryHM10.Models;
using LibraryServises.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryEntities;

namespace LibraryServises;

public interface ILibraryService
{
    public void CreateLibrary(CreateLibraryModel createLibraryModel);

    public void CreateBook(CreateBookModel createBookModel);

    public void PrintLibraries();

    public void PrintBooks(int libraryId);
}