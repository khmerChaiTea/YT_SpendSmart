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

        // Constructor to initialize the HomeController with a logger instance.
        // Dependency injection is used to provide the logger, which allows for better testability and separation of concerns.
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Action method to handle requests for the Index view.
        // This method returns the default view associated with the Index action.
        // It typically serves as the landing page or homepage of the application.
        public IActionResult Index()
        {
            return View();
        }

        // Action method to handle requests for the Expenses view.
        // This method returns the default view associated with the Expenses action.
        // It is intended to display a list of expenses or related information.
        public IActionResult Expenses()
        {
            return View();
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
        // This method is responsible for processing the form data, such as saving it to a database.
        // Currently, it redirects to the Expenses action after processing.
        public IActionResult ExpenseForm(Expense model)
        {
            // TODO: Implement logic to handle the form submission.
            // This may include:
            // - Validating the model data to ensure it meets the required criteria.
            // - Saving the model data to a database.
            // - Logging any important information or errors.

            // Redirects to the Expenses action after processing the form data.
            // This behavior might be adjusted based on the application's requirements (e.g., redirect to a different page or show a confirmation message).
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
