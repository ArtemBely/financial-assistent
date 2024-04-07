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
    public class BudgetPresenter
    {

        private readonly IBudgetService _budgetService;
        private AIHelperForm aIHelper;

        public BudgetPresenter(AIHelperForm aIHelper, IBudgetService budgetService)
        {
            this.aIHelper = aIHelper;
            _budgetService = budgetService;
        }

        public void SaveBudget(Budget budget)
        {
            _budgetService.AddBudget(budget);
        }
    }
}
