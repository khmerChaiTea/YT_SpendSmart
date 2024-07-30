using Microsoft.AspNetCore.Mvc;
using SpendSmart.Models;
using System.Diagnostics;

namespace SpendSmart.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly SpendSmartDbContext _context;

        // Constructor for HomeController. Initializes the logger and DbContext.
        // Dependency injection provides these services to the controller.
        public HomeController(ILogger<HomeController> logger, SpendSmartDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Action method for the Index view. 
        // This method returns the default view associated with the Index action.
        public IActionResult Index()
        {
            return View();
        }

        // Action method to retrieve and display all expenses.
        // Fetches the list of expenses from the database and calculates the total.
        public IActionResult Expenses()
        {
            var allExpenses = _context.Expenses.ToList(); // Retrieve all expenses from the database.

            var totalExpenses = allExpenses.Sum(x => x.Value); // Calculate the total value of all expenses.

            ViewBag.Expenses = totalExpenses; // Pass the total expenses value to the view using ViewBag.

            return View(allExpenses); // Return the view with the list of expenses.
        }

        // Action method for creating or editing an expense.
        // If an id is provided, it attempts to fetch the existing expense for editing.
        // If no id is provided, it initializes a new expense object for creating a new entry.
        public IActionResult CreateEditExpense(int? id)
        {
            if (id != null)
            {
                var expenseInDb = _context.Expenses.SingleOrDefault(expense => expense.Id == id);

                if (expenseInDb == null)
                {
                    return NotFound(); // Return a 404 Not Found if the expense does not exist.
                }

                return View(expenseInDb); // Return the view for editing the existing expense.
            }
            return View(new Expense()); // Return the view for creating a new expense.
        }

        // Action method to delete an expense.
        // Finds the expense by id and removes it from the database.
        // Redirects to the Expenses action method after deletion.
        public IActionResult DeleteExpense(int id)
        {
            var expenseInDb = _context.Expenses.SingleOrDefault(expense => expense.Id == id);

            if (expenseInDb == null)
            {
                return NotFound(); // Return a 404 Not Found if the expense does not exist.
            }

            _context.Expenses.Remove(expenseInDb); // Remove the expense from the DbSet.
            _context.SaveChanges(); // Save changes to the database.

            return RedirectToAction("Expenses"); // Redirect to the Expenses action method.
        }

        // Action method to handle form submissions for creating or editing an expense.
        // Depending on whether the expense has an Id, it adds or updates the expense in the database.
        public IActionResult ExpenseForm(Expense model)
        {
            if (model.Id == 0)
            {
                _context.Expenses.Add(model); // Add a new expense if Id is 0 (new expense).
            }
            else
            {
                _context.Expenses.Update(model); // Update the existing expense if Id is not 0.
            }

            _context.SaveChanges(); // Save changes to the database.

            return RedirectToAction("Expenses"); // Redirect to the Expenses action method.
        }

        // Action method for displaying the Privacy view.
        public IActionResult Privacy()
        {
            return View();
        }

        // Action method for displaying error information.
        // Configured with the ResponseCache attribute to prevent caching of error pages.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
