using webAPI.Context;
using webAPI.Models;

namespace webAPI.Services;

public class CategoryService : ICategoryService
{
    private DbWebAPIContext _context;

    public CategoryService(DbWebAPIContext context)
    {
        _context = context;
    }

    public IEnumerable<CategoryModel> GetCategories()
    {
        return _context.Categories;
    }

    public async Task SaveCategoryAsync(CategoryModel category)
    {
        _context.Add(category);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateCategoryAsync(Guid id, CategoryModel category)
    {
        CategoryModel? actualCategory = _context.Categories.Find(id);

        if (actualCategory == null)
        {
            actualCategory = category;
            actualCategory.description = category.description;
            actualCategory.peso = category.peso;

            await _context.SaveChangesAsync();
        }
    }

    public async Task DeleteCategoryAsync(Guid id)
    {
        CategoryModel? actualCategory = _context.Categories.Find(id);

        if (actualCategory != null)
        {
            _context.Remove(actualCategory);

            await _context.SaveChangesAsync();
        }
    }
}

public interface ICategoryService
{
    IEnumerable<CategoryModel> GetCategories();
    Task SaveCategoryAsync(CategoryModel category);
    Task UpdateCategoryAsync(Guid id, CategoryModel category);
    Task DeleteCategoryAsync(Guid id);
}