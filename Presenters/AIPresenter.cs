using FinancialAssistent.Models;
using FinancialAssistent.Services;
using Microsoft.ML;

namespace FinancialAssistent.Presenters
{

    public class AIPresenter
    {
        private readonly ITransactionService _transactionService;
        private readonly IBudgetService _budgetService;
        private MLContext _mlContext;
        private ITransformer? _model;
        private PredictionEngine<Transaction, TransactionPrediction>? _predictionEngine;


        public AIPresenter()
        {
            _transactionService = new TransactionService();
            _budgetService = new BudgetService();
            _mlContext = new MLContext();
            LoadModel();
        }

        /// <summary>
        /// Loads the machine learning model from the disk if it exists, otherwise notifies the user to train the model.
        /// </summary>
        /// <remarks>
        /// If the model file does not exist, it sets the model and prediction engine to null and shows a MessageBox instructing the user to train the model.
        /// </remarks>
        private void LoadModel()
        {
            string modelPath = GetModelPath();
            if (File.Exists(modelPath))
            {
                DataViewSchema modelSchema;
                _model = _mlContext.Model.Load(modelPath, out modelSchema);
                _predictionEngine = _mlContext.Model.CreatePredictionEngine<Transaction, TransactionPrediction>(_model);
            }
            else
            {
                MessageBox.Show("To get budget advices from our AI Helper, please first train the model by clicking on the 'AI Training' button.", "Model Training Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _model = null;
                _predictionEngine = null;
            }
        }

        /// <summary>
        /// Trains a new model or increments an existing model with transaction data for a specified user.
        /// </summary>
        /// <param name="userId">The user ID for whom the transaction data will be used for training or updating the model.</param>
        /// <remarks>
        /// This method loads or creates a machine learning pipeline, trains or updates the model, and then evaluates and saves it.
        /// </remarks>
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

            IDataView dataView = _mlContext.Data.LoadFromEnumerable(transactions);

            string modelPath = GetModelPath();
            ITransformer model;

            if (File.Exists(modelPath))
            {

                DataViewSchema modelSchema;
                model = _mlContext.Model.Load(modelPath, out modelSchema);


                var pipeline = _mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: nameof(Transaction.Amount))
                    .Append(_mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "CategoryIdEncoded", inputColumnName: nameof(Transaction.CategoryId)))
                    .Append(_mlContext.Transforms.Concatenate("Features", "CategoryIdEncoded"))
                    .Append(_mlContext.Regression.Trainers.FastTree());

                model = pipeline.Fit(dataView);
            }
            else
            {
                var pipeline = _mlContext.Transforms.CopyColumns(outputColumnName: "Label", inputColumnName: nameof(Transaction.Amount))
                    .Append(_mlContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "CategoryIdEncoded", inputColumnName: nameof(Transaction.CategoryId)))
                    .Append(_mlContext.Transforms.Concatenate("Features", "CategoryIdEncoded"))
                    .Append(_mlContext.Regression.Trainers.FastTree());

                model = pipeline.Fit(dataView);
            }

            _mlContext.Model.Save(model, dataView.Schema, modelPath);

            EvaluateModel(_mlContext, model, dataView);
            LoadModel();
        }

        /// <summary>
        /// Retrieves the path to the machine learning model file.
        /// </summary>
        /// <returns>The full path to the machine learning model file.</returns>
        private string GetModelPath()
        {
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "model.zip");

        }

        /// <summary>
        /// Evaluates the trained machine learning model against a provided dataset.
        /// </summary>
        /// <param name="mlContext">The machine learning context.</param>
        /// <param name="model">The machine learning model to evaluate.</param>
        /// <param name="dataView">The data view containing the dataset for evaluation.</param>
        /// <remarks>
        /// Outputs the evaluation metrics, including R^2, to the console.
        /// </remarks>
        private void EvaluateModel(MLContext mlContext, ITransformer model, IDataView dataView)
        {
            var predictions = model.Transform(dataView);
            var metrics = mlContext.Regression.Evaluate(predictions);
            Console.WriteLine($"R^2: {metrics.RSquared}");
        }

        /// <summary>
        /// Provides budget advice based on previously trained model predictions for a specific user.
        /// </summary>
        /// <param name="userId">The user ID to retrieve budget advice for.</param>
        /// <returns>A list of budget advice or null if the model is not trained.</returns>
        /// <remarks>
        /// If the model is not trained, shows a MessageBox advising to train the model.
        /// Each advice is calculated by predicting monthly spending and adjusting the budget limits accordingly.
        /// </remarks>
        public List<BudgetAdvice>? GetBudgetAdvices(int userId)
        {
            if (_model == null)
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

        /// <summary>
        /// Predicts monthly spending for a specific category of transactions by a user.
        /// </summary>
        /// <param name="userId">The user ID for whom the prediction is made.</param>
        /// <param name="categoryId">The category ID for which the spending prediction is made.</param>
        /// <returns>The predicted spending amount based on budget and transactions history.</returns>
        private float PredictMonthlySpending(int userId, int categoryId)
        {
            if (_predictionEngine == null)
            {
                if (_model == null)
                {
                    _model = _mlContext.Model.Load("model.zip", out var modelInputSchema);
                }
                _predictionEngine = _mlContext.Model.CreatePredictionEngine<Transaction, TransactionPrediction>(_model);
            }

            var sampleTransaction = new Transaction { UserId = userId, CategoryId = categoryId, Date = DateTime.Now, Amount = 0 };
            var prediction = _predictionEngine.Predict(sampleTransaction);
            return prediction.Amount;
        }

        /// <summary>
        /// Predicts the transaction amount using the trained model and prediction engine.
        /// </summary>
        /// <param name="transaction">The transaction to predict.</param>
        /// <remarks>
        /// Initializes the prediction engine if not already done.
        /// </remarks>
        public void Predict(Transaction transaction)
        {
            if (_predictionEngine == null)
            {
                if (_model == null)
                {
                    _model = _mlContext.Model.Load("model.zip", out var modelInputSchema);
                }
                _predictionEngine = _mlContext.Model.CreatePredictionEngine<Transaction, TransactionPrediction>(_model);
            }

            var prediction = _predictionEngine.Predict(transaction);
            //MessageBox.Show($"Predicted value: {prediction.Amount}");
        }


    }

}
