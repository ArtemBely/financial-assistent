using FinancialAssistent.Models;
using FinancialAssistent.Services;
using FinancialAssistent.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAssistent.Presenters
{
    internal class CategoryPresenter
    {

        private TransactionForm transactionForm;

        private ICategoryService _categoryService;

        public CategoryPresenter(TransactionForm transactionForm, CategoryService categoryService)
        {
           this.transactionForm = transactionForm;
           _categoryService = categoryService;
        }

        public List<Category> LoadCategories()
        {
            var categories = _categoryService.GetCategories();
            transactionForm.UpdateCategories(categories);
            return categories;
        }


        public void SaveCategory(string category) {
            _categoryService.AddCategory(category);
        }

    }
}
