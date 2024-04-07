using FinancialAssistent.Models;
using FinancialAssistent.Presenters;
using FinancialAssistent.Services;

namespace FinancialAssistent.Views
{
    public partial class AIHelperForm : Form
    {

        private readonly ICategoryService _categoryService;
        private readonly int _userId;
        private BudgetPresenter _budgetPresenter;
        private List<Category> _categories;

        public AIHelperForm(int userId)
        {
            InitializeComponent();
            _categoryService = new CategoryService();
            _budgetPresenter = new BudgetPresenter(this, new BudgetService());
            _userId = userId;
        }

        private void Accept_Budget(object sender, EventArgs e)
        {
            if (categoryCombobox.SelectedValue is null)
            {
                MessageBox.Show("Please select a category.");
                return;
            }
            int categoryId = (int)categoryCombobox.SelectedValue;
            if (!decimal.TryParse(limitTextBox.Text, out decimal limit))
            {
                MessageBox.Show("Please enter a valid limit.");
                return;
            }

            Budget newBudget = new Budget
            {
                UserId = _userId,
                CategoryId = categoryId,
                Limit = limit
            };

            try {
                _budgetPresenter.SaveBudget(newBudget);
                MessageBox.Show("Budget limit was successfully added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AIHelperForm_Load(object sender, EventArgs e)
        {
            _categories = _categoryService.GetCategories();
            categoryCombobox.DataSource = _categories;
            categoryCombobox.DisplayMember = "CategoryName";
            categoryCombobox.ValueMember = "CategoryId";
        }
    }
}
