using FinancialAssistent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
