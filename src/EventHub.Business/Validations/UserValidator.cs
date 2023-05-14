using System.Diagnostics.CodeAnalysis;
using EventHub.Entities;
using FluentValidation;

namespace EventHub.Business.Validations;

internal sealed class UserValidator : AbstractValidator<User>
{
    [StringSyntax(StringSyntaxAttribute.Regex)]
    private const string NameRegex = @"^[a-zA-ZÀ-ÿ]+([ '.][a-zA-ZÀ-ÿ]+)*$";

    public UserValidator()
    {
        RuleFor(x => x.Id)
            .Must(x => x != Guid.Empty)
            .WithMessage("Must be a valid ID");

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required")
            .EmailAddress()
            .WithMessage("Must be a valid email address");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required")
            .Length(min: 8, max: 20)
            .WithMessage("Password must be between 8 and 20 characters")
            .Matches(@"^(?=.*\d.*\d)(?=.*[A-Za-z])[A-Za-z0-9]+$")
            .WithMessage("Password must be between 8 and 20 characters and contain at least 2 digits");

        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First name is required")
            .Length(min: 2, max: 30)
            .WithMessage("First name must be between 2 and 30 characters")
            .Matches(NameRegex)
            .WithMessage("First name must contain only letters");

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last name is required")
            .Length(min: 2, max: 30)
            .WithMessage("Last name must be between 2 and 30 characters")
            .Matches(NameRegex)
            .WithMessage("Last name must contain only letters");
    }
}