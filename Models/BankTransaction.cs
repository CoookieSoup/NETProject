namespace NETProject.Models
{
    public class BankTransaction
    {
        public int Id { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime PostedDate { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public string? Merchant { get; set; }
        public string? Category { get; set; }
    }
}