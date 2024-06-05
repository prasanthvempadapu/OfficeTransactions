using System.ComponentModel.DataAnnotations;

namespace OfficeTransactions.Models
{
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Amount { get; set; }
        public int Balance { get; set; }
        public Transaction() { }

    }
}
