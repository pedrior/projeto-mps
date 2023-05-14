using EventHub.Entities;
using FluentValidation;

namespace EventHub.Business.Validations;

internal sealed class CategoryValidator : AbstractValidator<Category>
{
    public CategoryValidator()
    {
        RuleFor(x => x.Id)
            .Must(x => x != Guid.Empty)
            .WithMessage("Must be a valid ID");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .Length(min: 2, max: 50)
            .WithMessage("Name must be between 2 and 50 characters");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required")
            .Length(min: 20, max: 200)
            .WithMessage("Description must be between 20 and 200 characters");
    }
}