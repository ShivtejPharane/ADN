using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace CRMProject.Pages.Leads
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public LeadCreateModel Lead { get; set; } = new();

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                using var connection = new MySqlConnection("Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=manager;");
                connection.Open();

                string sql = "INSERT INTO leads (name, email, phone, company, status) VALUES (@name, @email, @phone, @company, @status)";
                using var command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@name", Lead.Name);
                command.Parameters.AddWithValue("@email", Lead.Email);
                command.Parameters.AddWithValue("@phone", Lead.Phone ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@company", Lead.Company ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@status", Lead.Status ?? "New");

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error adding lead: " + ex.Message);
                return Page();
            }

            return RedirectToPage("Index");
        }
    }

    public class LeadCreateModel
    {
        [Required(ErrorMessage = "Enter the name")]
        public string Name { get; set; } = "";

        [Required(ErrorMessage = "Enter the email")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = "";

        public string? Phone { get; set; }
        public string? Company { get; set; }
        
        [Required]
        public string Status { get; set; } = "New";
    }
}
