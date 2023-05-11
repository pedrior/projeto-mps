using EventHub.Core.Entities;

namespace EventHub.Business.Entities.Categories;

public sealed class Category : Entity<CategoryId>
{
    public override CategoryId Id { get; init; } = CategoryId.New();

    public required string Name { get; set; }

    public required string Description { get; set; }
}

public class CategoryRepository : Entity<CategoryId>
{
    private const string FilePath = "categories.txt";

    public void Add(Category category, CategoryId id)
    {
        id = CategoryId.New();
        var categories = GetAllCategories();
        categories.Add(category);
        SaveCategoriesToFile(categories);
    }

    public void Update(Category category)
    {
        var categories = GetAllCategories();
        var existingCategory = categories.Find(c => c.Id == category.Id);
        if (existingCategory != null)
        {
            existingCategory.Name = category.Name;
            existingCategory.Description = category.Description;
            SaveCategoriesToFile(categories);
        }
    }

    public void Delete(CategoryId id)
    {
        var categories = GetAllCategories();
        var categoryToRemove = categories.Find(c => c.Id == id);
        if (categoryToRemove != null)
        {
            categories.Remove(categoryToRemove);
            SaveCategoriesToFile(categories);
        }
    }

    public Category GetById(CategoryId id)
    {
        var categories = GetAllCategories();
        return categories.Find(c => c.Id == id) ?? throw new InvalidOperationException("Category not found.");
    }

    public List<Category> GetAll()
    {
        return GetAllCategories();
    }

    private List<Category> GetAllCategories()
    {
        if (!File.Exists(FilePath))
        {
            return new List<Category>();
        }

        var categories = new List<Category>();
        using (var reader = new StreamReader(FilePath))
        {
            string? line;
            while ((line = reader.ReadLine()) != null)
            {
                var categoryData = line.Split(';');
                if (categoryData.Length >= 3)
                {
                    var category = new Category
                    {
                        Id = new CategoryId(categoryData[0]),
                        Name = categoryData[1],
                        Description = categoryData[2]
                    };
                    categories.Add(category);
                }
            }
        }

        return categories;
    }

    private void SaveCategoriesToFile(List<Category> categories)
    {
        using (var writer = new StreamWriter(FilePath))
        {
            foreach (var category in categories)
            {
                writer.WriteLine($"{category.Id};{category.Name};{category.Description}");
            }
        }
    }

    public static void Add(Category category)
    {
        throw new NotImplementedException();
    }

    public static object GetById(object id)
    {
        throw new NotImplementedException();
    }
}  
