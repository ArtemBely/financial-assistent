using FinancialAssistent.Models;

namespace FinancialAssistent.Repositories
{
    internal interface IBudgetRepository
    {
        void AddBudget(Budget budget);
        Budget FindByUserAndCategory(int userId, int categoryId);
        List<Budget> FindAllByUser(int userId);
        void UpdateBudget(Budget budget);
    }
}
