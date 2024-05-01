using FinancialAssistent.Models;

namespace FinancialAssistent.Services
{
    internal interface ICategoryService
    {
        List<Category> GetCategories();
        bool AddCategory(string category);
        void RemoveCategory(string categoryName);
        void UpdateCategory(Category category);
    }
}
