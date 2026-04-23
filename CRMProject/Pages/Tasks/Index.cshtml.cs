using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace CRMProject.Pages.Tasks
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<TaskInfo> ListTasks { get; set; } = new();

        public void OnGet() 
        { 
            try
            { 
                using (var connection = new MySqlConnection("Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=manager;")) 
                { 
                    connection.Open();    
                    var command = new MySqlCommand("SELECT id, title, description, due_date, is_completed FROM tasks ORDER BY due_date ASC", connection); 
                    using (var reader = command.ExecuteReader()) 
                    { 
                        while (reader.Read()) 
                        { 
                            ListTasks.Add(new TaskInfo 
                            { 
                                Id = reader.GetInt32(0),    
                                Title = reader.IsDBNull(1) ? "" : reader.GetString(1), 
                                Description = reader.IsDBNull(2) ? "" : reader.GetString(2), 
                                DueDate = reader.IsDBNull(3) ? null : reader.GetDateTime(3),
                                IsCompleted = reader.IsDBNull(4) ? false : reader.GetBoolean(4)
                            }); 
                        } 
                    } 
                } 
            } 
            catch (Exception ex)
            { 
                Console.WriteLine($"Error retrieving tasks: {ex.Message}"); 
            }             
        } 
    }

    public class TaskInfo
    {
        public int Id { get; set; } 
        public string? Title { get; set; } 
        public string? Description { get; set; } 
        public DateTime? DueDate { get; set; } 
        public bool IsCompleted { get; set; }
    }
}
