using Microsoft.EntityFrameworkCore;

namespace SpendSmart.Models
{
    // Represents the database context for the SpendSmart application.
    // Provides access to the database and the tables defined by DbSet properties.
    public class SpendSmartDbContext : DbContext
    {
        // Gets or sets the collection of Expenses in the database.
        public DbSet<Expense> Expenses { get; set; }

        // Initializes a new instance of the SpendSmartDbContext class.
        // Takes options to configure the context.
        public SpendSmartDbContext(DbContextOptions<SpendSmartDbContext> options)
            : base(options)
        {
        }
    }
}

