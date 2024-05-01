using FinancialAssistent.Models;

namespace FinancialAssistent.Repositories
{
    internal interface ICategoryRepository
    {
        List<Category> FetchCategories();
        bool AddCategory(string category);
        void RemoveCategory(string categoryName);
        void UpdateCategory(Category category);
    }
}
