using Microsoft.EntityFrameworkCore;
using OfficeTransactions.Models;

namespace OfficeTransactions.Data
{
    public class TransactionsDbContext :DbContext
    {
        public TransactionsDbContext(DbContextOptions options) : base(options) { 
        }
        public DbSet<Transaction> trasactions { get; set; }
    }
}
