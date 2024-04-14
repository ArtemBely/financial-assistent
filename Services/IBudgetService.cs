using FinancialAssistent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAssistent.Services
{
    public interface IBudgetService
    {
        void AddBudget(Budget budget);
        Budget FindByUserAndCategory(int userId, int categoryId);
        List<Budget> FindAllByUser(int userId);
        void UpdateBudget(Budget budget);
    }
}
