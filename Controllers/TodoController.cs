using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NETProject.Data;
using NETProject.Models;

namespace NETProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TodoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodos()
        {
            return await _context.TodoItems.ToListAsync();
        }

        [HttpGet("transactions")]
        public async Task<ActionResult<IEnumerable<BankTransaction>>> GetTransactions()
        {
            return await _context.BankTransactions.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoItem>> GetTodo(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpGet("transactions/{merchant}")]
        public async Task<ActionResult<IEnumerable<BankTransaction>>> GetTransactionsByMerchant(string merchant)
        {
            var transactions = await _context.BankTransactions
                .Where(t => t.Merchant != null && t.Merchant.ToLower() == merchant.ToLower())
                .ToListAsync();
            
            if (transactions.Count == 0)
            {
                return NotFound(new { Message = $"No transactions found for merchant: {merchant}" });
            }
            
            return Ok(transactions);
        }

        [HttpPost]
        public async Task<ActionResult<TodoItem>> CreateTodo(TodoItem item)
        {
            item.CreatedAt = DateTime.UtcNow;
            _context.TodoItems.Add(item);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTodos), new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TodoItem>> DeleteTodo(int id)
        {
            var item = await _context.TodoItems.FindAsync(id);
            if (item == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(item);
            await _context.SaveChangesAsync();
            return item;
        }
        [HttpPost("transactions/bulk")]
        public async Task<ActionResult> UploadTransactions(List<BankTransaction> transactions)
        {
            _context.BankTransactions.AddRange(transactions);
            await _context.SaveChangesAsync();
            return Ok(new { Message = $"Uploaded {transactions.Count} transactions" });
        }
    }
}