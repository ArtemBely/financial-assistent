using FinancialAssistent.Models;

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
