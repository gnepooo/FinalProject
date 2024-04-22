// Transaction.cs
namespace FinalProject.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal Amount { get; set; }
        // Add other properties for Transaction
    }
}
