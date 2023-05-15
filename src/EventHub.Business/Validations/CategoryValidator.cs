using EventHub.Entities;

namespace EventHub.Business.Validations;

internal sealed class CategoryValidator : Validator<Category>
{
    public CategoryValidator()
    {
        NewRule(x => x.Id != Guid.Empty, "Must be a valid ID");

        NewRule(x => !string.IsNullOrEmpty(x.Name), "Name is required");
        NewRule(x => x.Name.Length is >= 2 and <= 50, "Name must be between 2 and 50 characters");

        NewRule(x => !string.IsNullOrEmpty(x.Description), "Description is required");
        NewRule(x => x.Description.Length is >= 2 and <= 50, "Description must be between 20 and 200 characters");
    }
}