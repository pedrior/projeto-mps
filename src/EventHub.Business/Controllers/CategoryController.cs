using EventHub.Business.Exceptions;
using EventHub.Business.Validations;
using EventHub.Entities;
using EventHub.Infrastructure.Persistence.Context;
using EventHub.Infrastructure.Persistence.Repositories;
using FluentValidation;

namespace EventHub.Business.Controllers;

public sealed class CategoryController
{
    private readonly DbContext dbContext;
    private readonly ICategoryRepository categoryRepository;
    private readonly IValidator<Category> categoryValidator;

    public CategoryController()
    {
        dbContext = new DbFactory().GetDefaultContext();
        categoryRepository = new CategoryRepository(dbContext);
        categoryValidator = new CategoryValidator();
    }

    public IEnumerable<Category> GetAllCategories() => categoryRepository.GetAll();

    public Category? GetCategoryById(Guid id) => categoryRepository.GetById(id);

    public Category? GetCategoryByName(string name) => categoryRepository.FindByName(name);

    public void AddCategory(Category category)
    {
        categoryValidator.ValidateAndThrow(category);

        categoryRepository.Add(category);
        dbContext.SaveChanges();
    }

    public void UpdateCategory(Category category)
    {
        if (!categoryRepository.Any(c => c.Id == category.Id))
        {
            throw new CategoryNotFoundException($"Category not found with id: {category.Id}");
        }

        categoryValidator.ValidateAndThrow(category);

        categoryRepository.Update(category);
        dbContext.SaveChanges();
    }

    public void DeleteCategoryById(Guid categoryId)
    {
        var category = categoryRepository.GetById(categoryId);
        if (category is null)
        {
            throw new CategoryNotFoundException($"Category not found with id: {categoryId}");
        }

        categoryRepository.Delete(category);
        dbContext.SaveChanges();
    }
}