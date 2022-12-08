using FluentValidation;
using LibraryServises.Models;

namespace LibraryServises.Validators;

internal class CreateLibraryModelValidator : AbstractValidator<CreateLibraryModel>
{
    public CreateLibraryModelValidator()
    {
        RuleFor(createLibraryModel => createLibraryModel.Name)
            .NotEmpty()
            .WithMessage("Library Name required");
    }
}