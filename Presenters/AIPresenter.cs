using FinancialAssistent.Models;
using FinancialAssistent.Services;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.FastTree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialAssistent.Presenters
{

    public class AIPresenter
    {
        private readonly ITransactionService _transactionService;
        private readonly IBudgetService _budgetService;
        private MLContext mlContext;
        private ITransformer model;

        public AIPresenter()
        {
            _transactionService = new TransactionService();
            _budgetService = new BudgetService();
            mlContext = new MLContext();
        }


        //public void TrainModel(int userId)
        //{
        //    List<Transaction> transactions = _transactionService.GetTransactionsForUser(userId)
        //        .Select(t => new Transaction
        //        {
        //            UserId = t.UserId,
        //            Date = t.Date,
        //            Amount = t.Amount, // Конвертация decimal в float
        //            CategoryId = t.CategoryId
        //        }).ToList();

        //    IDataView dataView = mlContext.Data.LoadFromEnumerable(transactions);

        //    var pipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: nameof(Transaction.Amount))
        //        .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "CategoryIdEncoded", inputColumnName: nameof(Transaction.CategoryId)))
        //        .Append(mlContext.Transforms.Concatenate("Features", "CategoryIdEncoded"))
        //        .Append(mlContext.Regression.Trainers.FastTree());


        //    var dataSplit = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
        //    model = pipeline.Fit(dataSplit.TrainSet);

        //    var predictions = model.Transform(dataSplit.TestSet);
        //    var metrics = mlContext.Regression.Evaluate(predictions);
        //    Console.WriteLine($"R^2: {metrics.RSquared}");

        //    string currentDir = Directory.GetCurrentDirectory();

        //    string modelPath = Path.Combine(currentDir, @"..\..\..\model.zip");

        //    mlContext.Model.Save(model, dataView.Schema, modelPath);

        //}
        public void TrainOrIncrementModel(int userId)
        {
            List<Transaction> transactions = _transactionService.GetTransactionsForUser(userId)
                .Select(t => new Transaction
                {
                    UserId = t.UserId,
                    Date = t.Date,
                    Amount = t.Amount,
                    CategoryId = t.CategoryId
                }).ToList();

            IDataView dataView = mlContext.Data.LoadFromEnumerable(transactions);

            string modelPath = GetModelPath();
            ITransformer model;

            if (File.Exists(modelPath))
            {

                DataViewSchema modelSchema;
                model = mlContext.Model.Load(modelPath, out modelSchema);


                var pipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: nameof(Transaction.Amount))
                    .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "CategoryIdEncoded", inputColumnName: nameof(Transaction.CategoryId)))
                    .Append(mlContext.Transforms.Concatenate("Features", "CategoryIdEncoded"))
                    .Append(mlContext.Regression.Trainers.FastTree());

                model = pipeline.Fit(dataView);
            }
            else
            {
                var pipeline = mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: nameof(Transaction.Amount))
                    .Append(mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "CategoryIdEncoded", inputColumnName: nameof(Transaction.CategoryId)))
                    .Append(mlContext.Transforms.Concatenate("Features", "CategoryIdEncoded"))
                    .Append(mlContext.Regression.Trainers.FastTree());

                model = pipeline.Fit(dataView);
            }

            mlContext.Model.Save(model, dataView.Schema, modelPath);

            EvaluateModel(mlContext, model, dataView);
        }


        private string GetModelPath()
        {
            string currentDir = Directory.GetCurrentDirectory();
            return Path.Combine(currentDir, @"..\..\..\model.zip");
        }

        private void EvaluateModel(MLContext mlContext, ITransformer model, IDataView dataView)
        {
            var predictions = model.Transform(dataView);
            var metrics = mlContext.Regression.Evaluate(predictions);
            Console.WriteLine($"R^2: {metrics.RSquared}");
        }

        //public List<BudgetAdvice> GetBudgetAdvices(int userId)
        //{
        //    List<Budget> budgets = _budgetService.FindAllByUser(userId);
        //    List<Transaction> recentTransactions = _transactionService.GetRecentTransactionsForUser(userId);

        //    IDataView recentDataView = mlContext.Data.LoadFromEnumerable(recentTransactions);
        //    var monthModel = TrainMonthlyModel(recentDataView);

        //    List<BudgetAdvice> advices = new List<BudgetAdvice>();

        //    foreach (var budget in budgets)
        //    {
        //        var monthlyPrediction = PredictMonthlySpending(monthModel, userId, budget.CategoryId, recentDataView);
        //        decimal suggestedLimit = budget.Limit - Convert.ToDecimal(monthlyPrediction);

        //        advices.Add(new BudgetAdvice
        //        {
        //            CategoryId = budget.CategoryId,
        //            SuggestedLimit = suggestedLimit > 0 ? suggestedLimit : 0
        //        });
        //    }

        //    return advices;
        //}
        public List<BudgetAdvice> GetBudgetAdvices(int userId)
        {
            List<Budget> budgets = _budgetService.FindAllByUser(userId);
            List<Transaction> recentTransactions = _transactionService.GetRecentTransactionsForUser(userId);

            IDataView dataView = mlContext.Data.LoadFromEnumerable(recentTransactions);

            string modelPath = GetModelPath();
            DataViewSchema modelSchema;
            ITransformer model = mlContext.Model.Load(modelPath, out modelSchema);

            List<BudgetAdvice> advices = new List<BudgetAdvice>();

            foreach (var budget in budgets)
            {
                var monthlyPrediction = PredictMonthlySpending(model, userId, budget.CategoryId, dataView);
                decimal suggestedLimit = budget.Limit - Convert.ToDecimal(monthlyPrediction);

                advices.Add(new BudgetAdvice
                {
                    CategoryId = budget.CategoryId,
                    SuggestedLimit = suggestedLimit > 0 ? suggestedLimit : 0
                });
            }

            return advices;
        }


        private float PredictMonthlySpending(ITransformer model, int userId, int categoryId, IDataView dataView)
        {
            var predictionEngine = mlContext.Model.CreatePredictionEngine<Transaction, TransactionPrediction>(model);
            var sampleTransaction = new Transaction { UserId = userId, CategoryId = categoryId, Date = DateTime.Now, Amount = 0 };
            var prediction = predictionEngine.Predict(sampleTransaction);

            return prediction.Amount;
        }


        public void Predict(Transaction transaction)
        {

            if (model == null)
            {
                model = mlContext.Model.Load("model.zip", out var modelInputSchema);
            }

            var predEngine = mlContext.Model.CreatePredictionEngine<Transaction, TransactionPrediction>(model);

            var prediction = predEngine.Predict(transaction);
            MessageBox.Show($"Predicted value: {prediction.Amount}");
        }

    }

}
