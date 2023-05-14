using EventHub.Entities;
using FluentValidation;

namespace EventHub.Business.Validations;

internal sealed class EventValidator : AbstractValidator<Event>
{
    public EventValidator()
    {
        RuleFor(x => x.Id)
            .Must(x => x != Guid.Empty)
            .WithMessage("Must be a valid ID");

        RuleFor(x => x.Capacity)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Capacity must be greater than or equal to 1");

        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required")
            .Length(min: 2, max: 100)
            .WithMessage("Name must be between 2 and 100 characters");

        RuleFor(x => x.Description)
            .NotEmpty()
            .WithMessage("Description is required")
            .Length(min: 2, max: 1000)
            .WithMessage("Description must be between 2 and 1000 characters");

        RuleFor(x => x.StartDate)
            .GreaterThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("Start date must be greater than or equal to the current date");

        RuleFor(x => x.EndDate)
            .GreaterThanOrEqualTo(x => x.StartDate)
            .WithMessage("End date must be greater than or equal to the start date");
    }
}