using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace CRMProject.Pages.Tasks
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public TaskCreateModel TaskItem { get; set; } = new();

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

                string sql = "INSERT INTO tasks (title, description, due_date, is_completed) VALUES (@title, @description, @due_date, @is_completed)";
                using var command = new MySqlCommand(sql, connection);

                command.Parameters.AddWithValue("@title", TaskItem.Title);
                command.Parameters.AddWithValue("@description", TaskItem.Description ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@due_date", TaskItem.DueDate ?? (object)DBNull.Value);
                command.Parameters.AddWithValue("@is_completed", TaskItem.IsCompleted);

                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Error adding task: " + ex.Message);
                return Page();
            }

            return RedirectToPage("Index");
        }
    }

    public class TaskCreateModel
    {
        [Required(ErrorMessage = "Enter the title")]
        public string Title { get; set; } = "";

        public string? Description { get; set; }
        
        public DateTime? DueDate { get; set; }
        
        public bool IsCompleted { get; set; } = false;
    }
}
