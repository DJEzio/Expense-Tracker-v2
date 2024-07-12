using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorApp1.Data.Models
{
    public class Income
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public decimal Amount { get; set; }

        [Required]
        public IncomeType Type { get; set; }
    }

    public enum IncomeType
    {
        Salary,
        Scholarship,
        Gift,
        LuckyWinnings
    }
}
