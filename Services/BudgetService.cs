using FinancialAssistent.Models;
using FinancialAssistent.Repositories;

namespace FinancialAssistent.Services
{
    public class BudgetService : IBudgetService
    {

        private readonly string _connectionString;

        private BudgetRepository _repository;

        public BudgetService()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            _repository = new BudgetRepository(_connectionString);
        }

        public void AddBudget(Budget budget)
        {
            _repository.AddBudget(budget);
        }

        public List<Budget> FindAllByUser(int userId)
        {
            return _repository.FindAllByUser(userId);
        }

        public Budget FindByUserAndCategory(int userId, int categoryId)
        {
            return _repository.FindByUserAndCategory(userId, categoryId);
        }

        public void UpdateBudget(Budget budget)
        {
            _repository.UpdateBudget(budget);
        }
    }
}
