using Microsoft.AspNetCore.Mvc;
using SpendSmart.Models;
using System.Diagnostics;

namespace SpendSmart.Controllers
{
    public class HomeController : Controller
    {
        // Private field to hold the logger instance for this controller.
        // This logger is used for logging information, warnings, and errors related to this controller's operations.
        private readonly ILogger<HomeController> _logger;

        // Private field to hold the DbContext instance for database operations.
        // This context is used to interact with the database and perform CRUD operations. Create, Read, Update, and Delete
        private readonly SpendSmartDbContext _context;

        // Constructor to initialize the HomeController with a logger instance and a DbContext.
        // Dependency injection is used to provide these services, enabling better testability and separation of concerns.
        public HomeController(ILogger<HomeController> logger, SpendSmartDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // Action method to handle requests for the Index view.
        // This method returns the default view associated with the Index action.
        // It typically serves as the landing page or homepage of the application.
        public IActionResult Index()
        {
            return View();
        }

        // Action method to handle requests for the Expenses view.
        // This method retrieves a list of all expenses from the database and passes it to the view.
        // It is intended to display a list of expenses or related information to the user.
        public IActionResult Expenses()
        {
            // Retrieve all Expense entities from the database and convert them to a list.
            // This uses the DbContext to query the Expenses DbSet.
            var allExpenses = _context.Expenses.ToList();

            // Return the default view associated with the Expenses action.
            // Pass the list of expenses to the view so it can be displayed.
            // The view should be designed to handle and display this list of expenses.
            return View(allExpenses);
        }


        // Action method to handle requests for the Create/Edit Expense view.
        // This method returns the default view associated with the CreateEditExpense action.
        // It is used to either create a new expense or edit an existing one.
        public IActionResult CreateEditExpense()
        {
            return View();
        }

        // Action method to handle form submissions for creating or editing an expense.
        // Receives an Expense model object populated with form data from the view.
        // This method processes the form data and is responsible for saving it to the database.
        public IActionResult ExpenseForm(Expense model)
        {
            // Add the Expense model to the DbContext's Expenses DbSet.
            // This marks the model as added and prepares it for insertion into the database.
            _context.Expenses.Add(model);

            // Save the changes made in the DbContext to the database.
            // This persists the newly added or updated expense to the database.
            _context.SaveChanges();

            // TODO: Implement additional logic for handling the form submission:
            // - Validate the model data to ensure it meets the required criteria.
            // - Handle potential errors during data processing.
            // - Log relevant information or errors for debugging and auditing.

            // Redirects to the Expenses action after processing the form data.
            // This behavior could be adjusted based on application requirements,
            // such as redirecting to a different page, showing a confirmation message, or returning a view.
            return RedirectToAction("Expenses");
        }

        // Action method to handle requests for the Privacy view.
        // This method returns the default view associated with the Privacy action.
        // It typically provides information about the application's privacy policy.
        public IActionResult Privacy()
        {
            return View();
        }

        // Action method to handle requests for the Error view.
        // This method is decorated with the [ResponseCache] attribute to specify caching behavior.
        // It creates an ErrorViewModel with the current request ID or trace identifier.
        // The [ResponseCache] attribute configures the response to not be cached to ensure that errors are always displayed fresh.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            // Return the Error view with an ErrorViewModel containing the request ID.
            // This helps in troubleshooting by providing a unique identifier for the error request.
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
