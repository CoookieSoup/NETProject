namespace NETProject.Models
{
    public class BankTransaction
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        public string? Merchant { get; set; }
    }
}