using EventHub.Entities;

namespace EventHub.Business.Validations;

internal sealed class EventValidator : Validator<Event>
{
    public EventValidator()
    {
        NewRule(x => x.Id != Guid.Empty, "Must be a valid ID");

        NewRule(x => x.Capacity >= 1, "Capacity must be greater than or equal to 1");
        
        NewRule(x => !string.IsNullOrEmpty(x.Name), "Name is required");
        
        NewRule(x => x.Name.Length is >= 2 and <= 100, "Name must be between 2 and 100 characters");
        NewRule(x => !string.IsNullOrEmpty(x.Description), "Description is required");
        
        NewRule(x => x.Description.Length is >= 2 and <= 1000, "Description must be between 2 and 1000 characters");
        NewRule(x => x.StartDate >= DateTime.UtcNow, "Start date must be greater than or equal to the current date");
        
        NewRule(x => x.EndDate >= x.StartDate, "End date must be greater than or equal to the start date");
    }
}