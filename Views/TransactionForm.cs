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
        private AIPresenter _aiPresenter;
        private bool _categoriesLoaded = false;
        private List<Category> allCategories;
        private List<Transaction> allTransactions;


        public TransactionForm(int userId)
        {
            InitializeComponent();
            _userId = userId;
            ITransactionService transactionService = new TransactionService();
            _categoryPresenter = new CategoryPresenter(this, new CategoryService());
            _presenter = new TransactionPresenter(this, new TransactionService());
            _aiPresenter = new AIPresenter();
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

        private void TrainModelButton_Click(object sender, EventArgs e)
        {
            try
            {
                _aiPresenter.TrainOrIncrementModel(_userId);
                MessageBox.Show("The AI model has been successfully trained.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Mistake in AI training: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Edit_Transaction(object sender, EventArgs e)
        {
            var transactionId = GetSelectedTransactionId();
            if (!transactionId.HasValue)
            {
                return;
            }

            Transaction transactionToEdit = allTransactions.FirstOrDefault(t => t.TransactionId == transactionId.Value);
            if (transactionToEdit != null)
            {
                EditTransactionForm editForm = new EditTransactionForm(transactionToEdit, allCategories);
                editForm.TransactionUpdated += (sender, e) =>
                {
                    EditForm_TransactionUpdated(sender, e);
                    _aiPresenter.TrainOrIncrementModel(_userId);
                };
                editForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Transaction not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Edit_Category(object sender, EventArgs e)
        {
            string categoryName = GetSelectedCategoryName();
            if (string.IsNullOrEmpty(categoryName))
            {
                MessageBox.Show("Please select a category to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Category categoryToEdit = allCategories.FirstOrDefault(c => c.CategoryName.Equals(categoryName, StringComparison.OrdinalIgnoreCase));
            if (categoryToEdit != null)
            {
                EditTransactionForm editForm = new EditTransactionForm(categoryToEdit);
                editForm.CategoryUpdated += EditForm_CategoryUpdated;
                editForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Category not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void EditForm_TransactionUpdated(object sender, EventArgs e)
        {
            _presenter.LoadTransactions(_userId);
        }

        private void EditForm_CategoryUpdated(object sender, EventArgs e)
        {
            _categoryPresenter.LoadCategories();
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
                        Amount = (float)amount,
                        CategoryId = category.CategoryId
                    };

                    _presenter.SaveTransaction(transaction);
                    _aiPresenter.Predict(transaction);
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
            allTransactions = transactions;
            allTransactionListView.Items.Clear();

            if (allTransactionListView.Columns.Count == 0)
            {
                allTransactionListView.Columns.Add("ID", -2, HorizontalAlignment.Left);
                allTransactionListView.Columns.Add("Date", -2, HorizontalAlignment.Left);
                allTransactionListView.Columns.Add("Amount", -2, HorizontalAlignment.Left);
                allTransactionListView.Columns.Add("Category ID", -2, HorizontalAlignment.Left);
            }

            foreach (var transaction in transactions)
            {
                var item = new ListViewItem($"{transaction.TransactionId}");
                item.SubItems.Add(transaction.Date.ToShortDateString());
                item.SubItems.Add(transaction.Amount.ToString());
                item.SubItems.Add(transaction.CategoryId.ToString());

                allTransactionListView.Items.Add(item);
            }
            allTransactionListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            allTransactionListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        public void UpdateCategories(List<Category> categories)
        {
            categoryCombobox.Items.Clear();
            allCategoryListView.Items.Clear();

            if (allCategoryListView.Columns.Count == 0)
            {
                allCategoryListView.Columns.Add("Category", -2, HorizontalAlignment.Left);
            }

            allCategories = categories;
            foreach (var category in categories)
            {
                categoryCombobox.Items.Add(category.CategoryName);
                var item = new ListViewItem($"{category.CategoryName}");
                allCategoryListView.Items.Add(item);
            }
            allCategoryListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            allCategoryListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
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

        private void Back_To_Profile(object sender, EventArgs e)
        {
            Close();
        }

        private void Delete_Transaction(object sender, EventArgs e)
        {
            var transactionId = GetSelectedTransactionId();
            if (!transactionId.HasValue)
            {
                return;
            }

            _presenter.RemoveTransaction(transactionId.Value);
            _presenter.LoadTransactions(_userId);
        }

        private void Delete_Category(object sender, EventArgs e)
        {
            var categoryName = GetSelectedCategoryName();
            if (string.IsNullOrEmpty(categoryName))
            {
                return;
            }

            _categoryPresenter.RemoveCategory(categoryName);
            _categoryPresenter.LoadCategories();
        }



        private int? GetSelectedTransactionId()
        {
            if (allTransactionListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a transaction.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            var selectedItem = allTransactionListView.SelectedItems[0];
            if (int.TryParse(selectedItem.Text, out int transactionId))
            {
                return transactionId;
            }
            return null;
        }

        private string GetSelectedCategoryName()
        {
            if (allCategoryListView.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a category.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            var selectedItem = allCategoryListView.SelectedItems[0];
            return selectedItem.Text;
        }


    }
}
