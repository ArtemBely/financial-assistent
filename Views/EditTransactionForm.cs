using FinancialAssistent.Models;
using FinancialAssistent.Presenters;
using FinancialAssistent.Services;

namespace FinancialAssistent.Views
{
    public partial class EditTransactionForm : Form
    {
        private readonly TransactionPresenter _presenter;
        private Transaction _transactionToEdit;
        private List<Category> _categories;
        public event EventHandler TransactionUpdated;

        public EditTransactionForm(Transaction transactionToEdit, List<Category> categories)
        {
            InitializeComponent();
            _transactionToEdit = transactionToEdit;
            _categories = categories;
            LoadCategories();
            _presenter = new TransactionPresenter(this, new TransactionService());
        }

        private void EditTransactionForm_Load(object sender, EventArgs e)
        {
            dateTimePicker2.Value = _transactionToEdit.Date;
            amountTextbox.Text = _transactionToEdit.Amount.ToString();
            categoryCombobox.SelectedItem = _transactionToEdit.CategoryId.ToString();
            saveBtn.Click += SaveBtn_Click;
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
            categoryCombobox.SelectedIndex = _categories.FindIndex(c => c.CategoryId == _transactionToEdit.CategoryId);
        }


        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                _transactionToEdit.Date = dateTimePicker2.Value;
                _transactionToEdit.Amount = decimal.Parse(amountTextbox.Text);
                _transactionToEdit.CategoryId = ((dynamic)categoryCombobox.SelectedItem).Value;
                _presenter.UpdateTransaction(_transactionToEdit);
                TransactionUpdated?.Invoke(this, EventArgs.Empty);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating transaction: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        //private void SaveBtn_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        _transactionToEdit.Date = dateTimePicker2.Value;
        //        _transactionToEdit.Amount = decimal.Parse(amountTextbox.Text);
        //        _transactionToEdit.CategoryId = ((dynamic)categoryCombobox.SelectedItem).Value;

        //        // Обновляем транзакцию
        //        _presenter.UpdateTransaction(_transactionToEdit);

        //        // После обновления загружаем актуальный список транзакций
        //        _presenter.LoadTransactions(_userId);

        //        // Показываем сообщение об успешном обновлении
        //        MessageBox.Show($"Transaction with ID {_transactionToEdit.TransactionId} was updated successfully.", "Transaction Updated", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //        // Закрываем форму с диалоговым результатом OK
        //        this.DialogResult = DialogResult.OK;
        //        this.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        // В случае ошибки показываем сообщение
        //        MessageBox.Show($"Error updating transaction: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}


        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }

}
