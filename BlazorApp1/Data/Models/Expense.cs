using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp1.Data.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Amount { get; set; }

        public bool Planned { get; set; }

        // Foreign key for Category
        public int CategoryId { get; set; }

        // Navigation property for Category
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
