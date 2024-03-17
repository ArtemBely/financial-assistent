using FinancialAssistent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
