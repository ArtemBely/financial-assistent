using FinancialAssistent.Models;
using FinancialAssistent.Presenters;
using FinancialAssistent.Services;

namespace FinancialAssistent.Views
{
    public partial class TransactionForm : Form
    {

        private readonly int _userId;
        private readonly TransactionPresenter _presenter;
        private CategoryPresenter _categoryPresenter;
        private bool _categoriesLoaded = false;
        private List<Category> allCategories;


        public TransactionForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            ITransactionService transactionService = new TransactionService();
            _categoryPresenter = new CategoryPresenter(this, new CategoryService());
            _presenter = new TransactionPresenter(this, new TransactionService());
        }

        private void TransactionForm_Load(object sender, EventArgs e)
        {
            _presenter.LoadTransactions(_userId);
            if (!_categoriesLoaded)
            {
                allCategories = _categoryPresenter.LoadCategories();
                _categoriesLoaded = true;
            }
        }

        private void AddTransactionBtn_Click(object sender, EventArgs e)
        {
            if (decimal.TryParse(amountBtn.Text, out decimal amount) && categoryCombobox.SelectedItem != null)
            {
                string selectedCategoryName = categoryCombobox.SelectedItem.ToString();
                var category = allCategories.FirstOrDefault(c => c.CategoryName == selectedCategoryName);
                if (category != null)
                {
                    var transaction = new Transaction
                    {
                        UserId = _userId,
                        Date = dateTimePicker1.Value,
                        Amount = amount,
                        CategoryId = category.CategoryId
                    };

                    _presenter.SaveTransaction(transaction);
                    _presenter.LoadTransactions(_userId);
                }
            }
            else
            {
                MessageBox.Show("Please ensure all fields are correctly filled out.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateTransactionsList(List<Transaction> transactions)
        {
            allTransactionListbox.Items.Clear();
            foreach (var transaction in transactions)
            {
                allTransactionListbox.Items.Add($"ID: {transaction.TransactionId}, Date: {transaction.Date.ToShortDateString()}, Amount: {transaction.Amount}, Category ID: {transaction.CategoryId}");
            }
        }

        public void UpdateCategories(List<Category> categories)
        {
            categoryCombobox.Items.Clear();
            allCategoryListbox.Items.Clear();
            allCategories = categories;
            foreach (var category in categories)
            {
                categoryCombobox.Items.Add(category.CategoryName);
                allCategoryListbox.Items.Add($"Category: {category.CategoryName}");
            }
        }


        public void RefreshCategories()
        {
            _categoriesLoaded = false;
            _categoryPresenter.LoadCategories();
        }

        private void Add_New_Category(object sender, EventArgs e)
        {
            string categoryName = newCategoryTextbox.Text.Trim();
            if (!string.IsNullOrEmpty(categoryName))
            {
                _categoryPresenter.SaveCategory(categoryName);
                newCategoryTextbox.Text = "";
                RefreshCategories();
            }
            else
            {
                MessageBox.Show("Category name cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

    }
}
