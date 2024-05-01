using FinancialAssistent.Models;
using FinancialAssistent.Services;
using FinancialAssistent.Views;

namespace FinancialAssistent.Presenters
{
    internal class CategoryPresenter
    {

        private TransactionForm transactionForm;

        private ICategoryService _iCategoryService;
        private EditTransactionForm _editTransactionForm;
        private CategoryService _categoryService;
        private AIHelperForm _aIHelperForm;

        public CategoryPresenter(TransactionForm transactionForm, CategoryService categoryService)
        {
            this.transactionForm = transactionForm;
            _iCategoryService = categoryService;
        }

        public CategoryPresenter(EditTransactionForm editTransactionForm, CategoryService categoryService)
        {
            _editTransactionForm = editTransactionForm;
            _iCategoryService = categoryService;
        }

        public CategoryPresenter(AIHelperForm aIHelperForm, CategoryService categoryService)
        {
            _aIHelperForm = aIHelperForm;
            _categoryService = categoryService;
        }

        public List<Category> LoadCategories()
        {
            var categories = _iCategoryService.GetCategories();
            transactionForm.UpdateCategories(categories);
            return categories;
        }


        public void SaveCategory(string category)
        {
            bool isSuccess = _iCategoryService.AddCategory(category);
            if (!isSuccess)
            {
                MessageBox.Show("Category with this name already exists. Please enter a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void RemoveCategory(string categoryName)
        {
            _iCategoryService.RemoveCategory(categoryName);
        }

        public void UpdateCategory(Category category)
        {
            _iCategoryService.UpdateCategory(category);
        }

    }
}
