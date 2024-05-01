using FinancialAssistent.Models;
using FinancialAssistent.Repositories;

namespace FinancialAssistent.Services
{
    internal class CategoryService : ICategoryService
    {
        private readonly string _connectionString;

        private CategoryRepository _categoryRepository;

        public CategoryService()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _categoryRepository = new CategoryRepository(_connectionString);
        }

        public bool AddCategory(string category)
        {
            return _categoryRepository.AddCategory(category);
        }

        public List<Category> GetCategories()
        {
            return _categoryRepository.FetchCategories();

        }

        public void RemoveCategory(string categoryName)
        {
            _categoryRepository.RemoveCategory(categoryName);
        }

        public void UpdateCategory(Category category)
        {
            _categoryRepository.UpdateCategory(category);
        }
    }
}
