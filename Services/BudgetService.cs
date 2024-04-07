﻿using FinancialAssistent.Models;
using FinancialAssistent.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialAssistent.Services
{
    public class BudgetService : IBudgetService
    {

        private readonly string _connectionString;

        private BudgetRepository repository;

        public BudgetService()
        {
            _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            repository = new BudgetRepository(_connectionString);
        }

        public void AddBudget(Budget budget)
        {
            repository.AddBudget(budget);
        }
    }
}
