using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace CRMProject.Pages.Customers
{
    public class DeleteModel : PageModel
    {
        private readonly ILogger<DeleteModel> _logger;

        public DeleteModel(ILogger<DeleteModel> logger)
        {
            _logger = logger;
        }

        // Binds the customer data so it can be displayed on the confirmation page
        [BindProperty]
        public CustomerInfo Customer { get; set; } = new CustomerInfo();

        // 1. GET: Fetches the customer data to show a confirmation screen
        public IActionResult OnGet(int id)
        {
            try
            {
                using (var connection = new MySqlConnection("Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=manager;"))
                {
                    connection.Open();
                    // Using a parameterized query to prevent SQL injection
                    var command = new MySqlCommand("SELECT * FROM customers WHERE Id = @id", connection);
                    command.Parameters.AddWithValue("@id", id);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Customer.Id = reader.GetInt32(0);
                            Customer.Name = reader.GetString(1);
                            Customer.Email = reader.GetString(2);
                            Customer.Phone = reader.GetString(3);
                        }
                        else
                        {
                            // If the customer doesn't exist, send them back to the list
                            return RedirectToPage("/Customers/Index");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving customer: {ex.Message}");
                return RedirectToPage("/Customers/Index");
            }

            return Page();
        }

        // 2. POST: Performs the actual deletion when the user clicks "Delete" on the confirmation page
        public IActionResult OnPost(int id)
        {
            try
            {
                using (var connection = new MySqlConnection("Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=manager;"))
                {
                    connection.Open();
                    // Executing the SQL DELETE command safely
                    var command = new MySqlCommand("DELETE FROM customers WHERE Id = @id", connection);
                    command.Parameters.AddWithValue("@id", id);
                    
                    command.ExecuteNonQuery();
                }

                // Set a success message to display on the Index page alert
                TempData["SuccessMessage"] = "Customer deleted successfully.";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting customer: {ex.Message}");
            }

            // Redirect back to the customer list
            return RedirectToPage("/Customers/Index");
        }
    }
}