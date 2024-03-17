using FinancialAssistent.Models;
using FinancialAssistent.Services;
using FinancialAssistent.Views;

namespace FinancialAssistent.Presenters
{
    internal class CategoryPresenter
    {

        private TransactionForm transactionForm;

        private ICategoryService _categoryService;
        private EditTransactionForm editTransactionForm;
        private CategoryService categoryService;

        public CategoryPresenter(TransactionForm transactionForm, CategoryService categoryService)
        {
           this.transactionForm = transactionForm;
           _categoryService = categoryService;
        }

        public CategoryPresenter(EditTransactionForm editTransactionForm, CategoryService categoryService)
        {
            this.editTransactionForm = editTransactionForm;
            _categoryService = categoryService;
        }

        public List<Category> LoadCategories()
        {
            var categories = _categoryService.GetCategories();
            transactionForm.UpdateCategories(categories);
            return categories;
        }


        public void SaveCategory(string category)
        {
            bool isSuccess = _categoryService.AddCategory(category);
            if (!isSuccess)
            {
                MessageBox.Show("Category with this name already exists. Please enter a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void RemoveCategory(string categoryName)
        {
            _categoryService.RemoveCategory(categoryName);
        }

        public void UpdateCategory(Category category)
        {
            _categoryService.UpdateCategory(category);
        }

    }
}
