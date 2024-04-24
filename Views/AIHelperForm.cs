using FinancialAssistent.Models;
using FinancialAssistent.Presenters;
using FinancialAssistent.Services;
using System.Text;

namespace FinancialAssistent.Views
{
    public partial class AIHelperForm : Form
    {

        private readonly ICategoryService _categoryService;
        private readonly int _userId;
        private BudgetPresenter _budgetPresenter;
        private AIPresenter _aiPresenter;
        private List<Category> _categories;

        public AIHelperForm(int userId)
        {
            InitializeComponent();
            _categoryService = new CategoryService();
            _budgetPresenter = new BudgetPresenter(this, new BudgetService());
            _aiPresenter = new AIPresenter();
            _categories = _categoryService.GetCategories();
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

            try
            {
                _budgetPresenter.SaveOrUpdateBudget(newBudget);
                MessageBox.Show("Budget limit was successfully updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnUpdateBudgetAdvices_Click(object sender, EventArgs e)
        {
            var advices = _aiPresenter.GetBudgetAdvices(_userId);
            if (advices != null)
            {
                DisplayAdvices(advices);
            }
        }

        private void DisplayAdvices(List<BudgetAdvice> advices)
        {
            var message = new StringBuilder();
            foreach (var advice in advices)
            {
                var categoryName = _categories.FirstOrDefault(c => c.CategoryId == advice.CategoryId)?.CategoryName ?? "Unknown Category";
                message.AppendLine($"{categoryName}: recommended actual limit {advice.SuggestedLimit:C}");
            }
            MessageBox.Show(message.ToString(), "Advices: ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void AIHelperForm_Load(object sender, EventArgs e)
        {
            categoryCombobox.DataSource = _categories;
            categoryCombobox.DisplayMember = "CategoryName";
            categoryCombobox.ValueMember = "CategoryId";
        }
    }
}
