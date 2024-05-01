using FinancialAssistent.Models;
using FinancialAssistent.Services;
using FinancialAssistent.Views;

namespace FinancialAssistent.Presenters
{
    public class BudgetPresenter
    {

        private readonly IBudgetService _budgetService;
        private AIHelperForm _aIHelper;

        public BudgetPresenter(AIHelperForm aIHelper, IBudgetService budgetService)
        {
            _aIHelper = aIHelper;
            _budgetService = budgetService;
        }

        public void SaveBudget(Budget budget)
        {
            _budgetService.AddBudget(budget);
        }

        public void SaveOrUpdateBudget(Budget budget)
        {
            var existingBudget = _budgetService.FindByUserAndCategory(budget.UserId, budget.CategoryId);
            if (existingBudget != null)
            {
                existingBudget.Limit = budget.Limit;
                _budgetService.UpdateBudget(existingBudget);
            }
            else
            {
                _budgetService.AddBudget(budget);
            }
        }
    }
}
