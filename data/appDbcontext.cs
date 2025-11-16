using Microsoft.EntityFrameworkCore;
using YourProjectName.Models;

namespace YourProjectName.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<TodoItem> TodoItems { get; set; }

        public DbSet<BankTransaction> BankTransactions { get; set; }
    }
}