using FinancialAssistent.Models;
using FinancialAssistent.Presenters;
using FinancialAssistent.Services;


namespace FinancialAssistent.Views
{
    public partial class EditTransactionForm : Form
    {
        private readonly TransactionPresenter _presenter;
        private readonly CategoryPresenter _categoryPresenter;
        private Transaction _transactionToEdit;
        private Category _categoryToEdit;
        private List<Category> _categories;
        private string _categoryNameToEdit;
        public event EventHandler TransactionUpdated;
        public event EventHandler CategoryUpdated;

        public EditTransactionForm(Transaction transactionToEdit, List<Category> categories)
        {
            InitializeComponent();
            _transactionToEdit = transactionToEdit;
            _categories = categories;
            categoryNameTextbox.Visible = false;
            LoadCategories();
            _presenter = new TransactionPresenter(this, new TransactionService());

            dateTimePicker2.Value = _transactionToEdit.Date;
            amountTextbox.Text = _transactionToEdit.Amount.ToString();
            categoryCombobox.SelectedValue = _transactionToEdit.CategoryId;

            saveBtn.Click += SaveTransactionBtn_Click;
            cancelBtn.Click += CancelBtn_Click;
        }

        public EditTransactionForm(Category categoryToEdit)
        {
            InitializeComponent();
            _categoryToEdit = categoryToEdit;
            _categoryPresenter = new CategoryPresenter(this, new CategoryService());

            dateTimePicker2.Visible = false;
            amountTextbox.Visible = false;
            categoryCombobox.Visible = false;

            categoryNameTextbox.Visible = true;
            categoryNameTextbox.Text = _categoryToEdit.CategoryName;
            editDialogLabel.Text = "Please, edit category name";
            Text = "Edit Category";

            saveBtn.Click += SaveCategoryBtn_Click;
            cancelBtn.Click += CancelBtn_Click;
        }

        private void LoadCategories()
        {
            categoryCombobox.DisplayMember = "Text";
            categoryCombobox.ValueMember = "Value";

            foreach (var category in _categories)
            {
                categoryCombobox.Items.Add(new { Text = category.CategoryName, Value = category.CategoryId });
            }
            if (_transactionToEdit != null)
            {
                categoryCombobox.SelectedIndex = _categories.FindIndex(c => c.CategoryId == _transactionToEdit.CategoryId);
            }
        }

        private void SaveTransactionBtn_Click(object sender, EventArgs e)
        {
            try
            {
                _transactionToEdit.Date = dateTimePicker2.Value;
                _transactionToEdit.Amount = (float)decimal.Parse(amountTextbox.Text);
                _transactionToEdit.CategoryId = ((dynamic)categoryCombobox.SelectedItem).Value;
                _presenter.UpdateTransaction(_transactionToEdit);
                TransactionUpdated?.Invoke(this, EventArgs.Empty);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating transaction: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Close();
            }
        }

        private void SaveCategoryBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (_categoryToEdit == null)
                {
                    MessageBox.Show("The category to edit has not been set.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                string newCategoryName = categoryNameTextbox.Text.Trim();
                if (string.IsNullOrWhiteSpace(newCategoryName))
                {
                    MessageBox.Show("Category name cannot be empty.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _categoryToEdit.CategoryName = newCategoryName;
                _categoryPresenter.UpdateCategory(_categoryToEdit);

                CategoryUpdated?.Invoke(this, EventArgs.Empty);
                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating category: {ex.Message}\nStack Trace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            finally
            {
                Close();
            }
        }



        private void CancelBtn_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void EditTransactionForm_Load(object sender, EventArgs e)
        {

        }

    }
}
