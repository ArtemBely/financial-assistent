using FinancialAssistent.Models;
using FinancialAssistent.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAssistent.Services
{
    internal class CategoryService : ICategoryService
    {
        private readonly string _connectionString;

        private CategoryRepository categoryRepository;

        public CategoryService()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            categoryRepository = new CategoryRepository(_connectionString);
        }

        public bool AddCategory(string category)
        {
            return categoryRepository.AddCategory(category);
        }

        public List<Category> GetCategories()
        {
            return categoryRepository.FetchCategories();

        }

        public void RemoveCategory(string categoryName)
        {
            categoryRepository.RemoveCategory(categoryName);
        }

        public void UpdateCategory(Category category)
        {
            categoryRepository.UpdateCategory(category);
        }
    }
}
