using System.ComponentModel.DataAnnotations;

namespace SpendSmart.Models
{
    public class Expense
    {
        // Gets or sets the unique identifier for the expense.
        public int Id { get; set; }

        // Gets or sets the monetary value of the expense.
        public decimal Value { get; set; }

        // Gets or sets a description of the expense.
        // This property is optional and can be null.
        [Required]
        public string? Description { get; set; }
    }
}
