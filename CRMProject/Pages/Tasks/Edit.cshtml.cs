using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace CRMProject.Pages.Tasks
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public TaskEditModel TaskItem { get; set; } = new();

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
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                using var connection = new MySqlConnection("Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=manager;");
                connection.Open();

                string sql = "UPDATE tasks SET title=@title, description=@description, due_date=@due_date, is_completed=@is_completed WHERE id=@id";
                using var command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@id", TaskItem.Id);
                command.Parameters.AddWithValue("@title", TaskItem.Title);
                command.Parameters.AddWithValue("@description", TaskItem.Description ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@due_date", TaskItem.DueDate ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@is_completed", TaskItem.IsCompleted);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error updating task: " + ex.Message);
                return Page();
            }

            return RedirectToPage("Index");
        }
    }

    public class TaskEditModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Enter the title")]
        public string Title { get; set; } = "";

        public string? Description { get; set; }
        
        public DateTime? DueDate { get; set; }
        
        public bool IsCompleted { get; set; }
    }
}
