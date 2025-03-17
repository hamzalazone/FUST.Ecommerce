using Fust.Ecommerce.Models;

namespace Fust.Ecommerce.Services;

public interface ICategoryDataAccess
{
    void AddCategory(Category category);
    void DeleteCategory(int Id);
    Category? GetCategory(int Id);
    IEnumerable<Category> GetCategories();
    void UpdateCategory(Category category);
}