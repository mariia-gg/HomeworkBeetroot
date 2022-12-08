using FluentValidation;
using FluentValidation.Results;
using LibraryEntities;
using LibraryServices.Models;

namespace LibraryServices.Validators;

internal class CreateLibraryModelValidator : AbstractValidator<CreateLibraryModel>
{
    public CreateLibraryModelValidator()
    {
        RuleFor(createLibraryModel => createLibraryModel.Name)
            .MinimumLength(1)
            .WithMessage("Library Name required");
    }
}