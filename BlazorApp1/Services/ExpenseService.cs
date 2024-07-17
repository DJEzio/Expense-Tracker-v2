using BlazorApp1.Data;
using BlazorApp1.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorApp1.Services
{
    public class ExpenseService
    {
        private readonly ExpenseTrackerContext _context;

        public ExpenseService(ExpenseTrackerContext context)
        {
            _context = context;
        }
        public async Task<List<Expense>> GetExpensesAsync()
        {
            return await _context.Expenses.Include(e => e.Category).ToListAsync();
        }
        public async Task<Expense> GetExpenseByIdAsync(int id)
        {
            return await _context.Expenses.Include(e => e.Category).FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task AddExpenseAsync(Expense expense)
        {
            expense.Date = expense.Date.ToUniversalTime();
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateExpenseAsync(Expense expense)
        {
            _context.Entry(expense).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteExpenseAsync(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                await _context.SaveChangesAsync();
            }
        }
        public async Task<List<Expense>> GetExpensesByCategoryAsync(int categoryId)
        {
            // Assuming _context is your ExpenseTrackerContext instance
            return await _context.Expenses
                                 .Where(e => e.CategoryId == categoryId)
                                 .ToListAsync();
        }
    }
}
