using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace CRMProject.Pages.Leads
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<LeadInfo> ListLeads { get; set; } = new();

        public void OnGet() 
        { 
            try
            { 
                using (var connection = new MySqlConnection("Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=manager;")) 
                { 
                    connection.Open();    
                    var command = new MySqlCommand("SELECT id, name, email, phone, company, status FROM leads ORDER BY created_at DESC", connection); 
                    using (var reader = command.ExecuteReader()) 
                    { 
                        while (reader.Read()) 
                        { 
                            ListLeads.Add(new LeadInfo 
                            { 
                                Id = reader.GetInt32(0),    
                                Name = reader.IsDBNull(1) ? "" : reader.GetString(1), 
                                Email = reader.IsDBNull(2) ? "" : reader.GetString(2), 
                                Phone = reader.IsDBNull(3) ? "" : reader.GetString(3),
                                Company = reader.IsDBNull(4) ? "" : reader.GetString(4),
                                Status = reader.IsDBNull(5) ? "" : reader.GetString(5)
                            }); 
                        } 
                    } 
                } 
            } 
            catch (Exception ex)
            { 
                Console.WriteLine($"Error retrieving leads: {ex.Message}"); 
            }             
        } 
    }

    public class LeadInfo
    {
        public int Id { get; set; } 
        public string? Name { get; set; } 
        public string? Email { get; set; } 
        public string? Phone { get; set; } 
        public string? Company { get; set; }
        public string? Status { get; set; }
    }
}
