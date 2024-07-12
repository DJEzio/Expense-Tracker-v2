using BlazorApp1.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp1.Data
{
    public class ExpenseTrackerContext : DbContext
    {

        public ExpenseTrackerContext(DbContextOptions<ExpenseTrackerContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>()
                            .HasOne(e => e.Category)
                            .WithMany(c => c.Expenses)
                            .HasForeignKey(e => e.CategoryId);
        }
    }
}
