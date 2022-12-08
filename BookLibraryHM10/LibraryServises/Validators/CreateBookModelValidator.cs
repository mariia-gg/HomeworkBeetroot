using BookLibraryHM10.Models;
using FluentValidation;



namespace LibraryServices.Validators;

internal class CreateBookModelValidator : AbstractValidator<CreateBookModel>
{
    public CreateBookModelValidator()
    {
        RuleFor(createBookModel => createBookModel.Name)
            .MinimumLength(1)   
            .WithMessage("Book Name required");

        RuleFor(createBookModel => createBookModel.Author)
            .MinimumLength(1)
            .WithMessage("Author Name required");

        RuleFor(createBookModel => createBookModel.Genre)
            .MinimumLength(1)
            .WithMessage("Genre required");

        RuleFor(createBookModel => createBookModel.PublicationYear).
            NotEqual(2)
            .WithMessage("Plase enter year clearly");
    }
}
