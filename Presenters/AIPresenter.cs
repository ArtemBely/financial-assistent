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
        private PredictionEngine<Transaction, TransactionPrediction> predictionEngine;


        public AIPresenter()
        {
            _transactionService = new TransactionService();
            _budgetService = new BudgetService();
            mlContext = new MLContext();
            LoadModel();

        }

        private void LoadModel()
        {
            string modelPath = GetModelPath();
            if (File.Exists(modelPath))
            {
                DataViewSchema modelSchema;
                model = mlContext.Model.Load(modelPath, out modelSchema);
                predictionEngine = mlContext.Model.CreatePredictionEngine<Transaction, TransactionPrediction>(model);
            }
            else
            {
                MessageBox.Show("To get budget advices from our AI Helper, please first train the model by clicking on the 'AI Training' button.", "Model Training Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                model = null;
                predictionEngine = null;
            }
        }

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
            LoadModel();
        }


        private string GetModelPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "model.zip");

        }

        private void EvaluateModel(MLContext mlContext, ITransformer model, IDataView dataView)
        {
            var predictions = model.Transform(dataView);
            var metrics = mlContext.Regression.Evaluate(predictions);
            Console.WriteLine($"R^2: {metrics.RSquared}");
        }

        public List<BudgetAdvice> GetBudgetAdvices(int userId)
        {
            if (model == null)
            {
                MessageBox.Show("To get budget advices from our AI Helper, please first train the model by clicking on the 'AI Training' button on Transactions page", "Model Training Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            List<Budget> budgets = _budgetService.FindAllByUser(userId);
            List<BudgetAdvice> advices = new List<BudgetAdvice>();

            foreach (var budget in budgets)
            {
                var monthlyPrediction = PredictMonthlySpending(userId, budget.CategoryId);
                decimal suggestedLimit = budget.Limit - Convert.ToDecimal(monthlyPrediction);

                advices.Add(new BudgetAdvice
                {
                    CategoryId = budget.CategoryId,
                    SuggestedLimit = suggestedLimit > 0 ? suggestedLimit : 0
                });
            }

            return advices;
        }


        private float PredictMonthlySpending(int userId, int categoryId)
        {
            if (predictionEngine == null)
            {
                if (model == null)
                {
                    model = mlContext.Model.Load("model.zip", out var modelInputSchema);
                }
                predictionEngine = mlContext.Model.CreatePredictionEngine<Transaction, TransactionPrediction>(model);
            }

            var sampleTransaction = new Transaction { UserId = userId, CategoryId = categoryId, Date = DateTime.Now, Amount = 0 };
            var prediction = predictionEngine.Predict(sampleTransaction);
            return prediction.Amount;
        }

        public void Predict(Transaction transaction)
        {
            if (predictionEngine == null)
            {
                if (model == null)
                {
                    model = mlContext.Model.Load("model.zip", out var modelInputSchema);
                }
                predictionEngine = mlContext.Model.CreatePredictionEngine<Transaction, TransactionPrediction>(model);
            }

            var prediction = predictionEngine.Predict(transaction);
            //MessageBox.Show($"Predicted value: {prediction.Amount}");
        }


    }

}
