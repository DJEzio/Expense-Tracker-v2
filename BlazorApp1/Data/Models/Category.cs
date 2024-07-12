﻿namespace BlazorApp1.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Navigation property to represent the relationship with Expense
        public ICollection<Expense> Expenses { get; set; }
    }
}
