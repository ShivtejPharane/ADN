using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace CRMProject.Pages.Tasks
{
    public class DeleteModel : PageModel
    {
        [BindProperty]
        public TaskInfo TaskItem { get; set; } = new();

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
                var command = new MySqlCommand("SELECT id, title, description, due_date, is_completed FROM tasks WHERE id = @id", connection);
                command.Parameters.AddWithValue("@id", id);
                using var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    TaskItem.Id = reader.GetInt32(0);
                    TaskItem.Title = reader.IsDBNull(1) ? "" : reader.GetString(1);
                    TaskItem.Description = reader.IsDBNull(2) ? "" : reader.GetString(2);
                    TaskItem.DueDate = reader.IsDBNull(3) ? null : reader.GetDateTime(3);
                    TaskItem.IsCompleted = reader.IsDBNull(4) ? false : reader.GetBoolean(4);
                }
                else
                {
                    return RedirectToPage("Index");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving task details: {ex.Message}");
                return RedirectToPage("Index");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            try
            {
                using var connection = new MySqlConnection("Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=manager;");
                connection.Open();

                string sql = "DELETE FROM tasks WHERE id=@id";
                using var command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", TaskItem.Id);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting task: {ex.Message}");
                return Page();
            }

            return RedirectToPage("Index");
        }
    }
}
