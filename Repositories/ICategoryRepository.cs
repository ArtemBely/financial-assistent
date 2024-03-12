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
        public List<Category> FetchCategories();
        public void AddCategory(string category);
    }
}
