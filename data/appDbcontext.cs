using Microsoft.EntityFrameworkCore;
using NETProject.Models;

namespace NETProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<TodoItem> TodoItems { get; set; }

        public DbSet<BankTransaction> BankTransactions { get; set; }
    }
}