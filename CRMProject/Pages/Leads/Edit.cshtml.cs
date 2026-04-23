using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace CRMProject.Pages.Leads
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public LeadEditModel Lead { get; set; } = new();

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return RedirectToPage("Index");
            }

            try
            {
                using var connection = new MySqlConnection("Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=manager;");
                connection.Open();
                var command = new MySqlCommand("SELECT id, name, email, phone, company, status FROM leads WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Lead.Id = reader.GetInt32(0);
                    Lead.Name = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    Lead.Email = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    Lead.Phone = reader.IsDBNull(3) ? "" : reader.GetString(3);
                    Lead.Company = reader.IsDBNull(4) ? "" : reader.GetString(4);
                    Lead.Status = reader.IsDBNull(5) ? "New" : reader.GetString(5);
                }
                else
                {
                    return RedirectToPage("Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving lead details: {ex.Message}");
                return RedirectToPage("Index");
            }

            return Page();
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

                string sql = "UPDATE leads SET name=@name, email=@email, phone=@phone, company=@company, status=@status WHERE id=@id";
                using var command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", Lead.Id);
                command.Parameters.AddWithValue("@name", Lead.Name);
                command.Parameters.AddWithValue("@email", Lead.Email);
                command.Parameters.AddWithValue("@phone", Lead.Phone ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@company", Lead.Company ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@status", Lead.Status ?? "New");

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error updating lead: " + ex.Message);
                return Page();
            }

            return RedirectToPage("Index");
        }
    }

    public class LeadEditModel
    {
        public int Id { get; set; }

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
