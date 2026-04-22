using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;
using System.ComponentModel.DataAnnotations;

namespace CRMProject.Pages.Customers
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public int Id { get; set; }

        [BindProperty, Required(ErrorMessage = "Enter the name")]
        public string name { get; set; } = "";

        [BindProperty, Required(ErrorMessage = "Enter the email"),
         EmailAddress(ErrorMessage = "Invalid email format")]
        public string email { get; set; } = "";

        [BindProperty, Required(ErrorMessage = "Enter the phone number")]
        public string phone { get; set; } = "";

        string connectionString = "Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=manager;";

        // 🔹 Load existing customer data
        public IActionResult OnGet(int id)
        {
            try
            {
                using var connection = new MySqlConnection(connectionString);
                connection.Open();

                // FIX: Changed from UPDATE to SELECT
                string sql = "SELECT * FROM customers WHERE Id=@id";
                using var command = new MySqlCommand(sql, connection);
                
                // We only need the ID parameter to fetch the data
                command.Parameters.AddWithValue("@id", id);

                using var reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Map the database columns to your properties
                    Id = reader.GetInt32("Id");
                    name = reader.GetString("name");
                    email = reader.GetString("email");
                    phone = reader.GetString("phone");
                }
                else
                {
                    // Customer not found in DB
                    return RedirectToPage("Index");
                }
            }
            catch (Exception ex)
            {
                // Good to log the error in the console so you know if it fails
                Console.WriteLine("Error in OnGet: " + ex.Message);
                return RedirectToPage("Index");
            }

            return Page();
        }

        // 🔹 Update customer
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                using var connection = new MySqlConnection(connectionString);
                connection.Open();

                string sql = "UPDATE customers SET name=@name, email=@email, phone=@phone WHERE Id=@id";
                using var command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@email", email);
                command.Parameters.AddWithValue("@phone", phone);
                command.Parameters.AddWithValue("@id", Id);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error updating customer: " + ex.Message);
                return Page();
            }

            TempData["SuccessMessage"] = "Customer updated successfully!";
            return RedirectToPage("Index");
        }
    }
}