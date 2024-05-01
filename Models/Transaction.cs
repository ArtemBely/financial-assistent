namespace FinancialAssistent.Models
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public float Amount { get; set; }
        public int CategoryId { get; set; }
    }
}
