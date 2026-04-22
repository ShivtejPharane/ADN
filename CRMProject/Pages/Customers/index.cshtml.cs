using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace CRMProject.Pages.Customers
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;

        public Index(ILogger<Index> logger)
        {
            _logger = logger;
        }

        public List<CustomerInfo> ListCustomers { get; set; } = new();

        public void OnGet() 
        { 
            try{ 
            using (var connection = new MySqlConnection("Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=manager;")) 
            { 
                connection.Open();    
                var command = new MySqlCommand("SELECT * FROM customers", 
connection); 
                using (var reader = command.ExecuteReader()) 
                { 
                    while (reader.Read()) 
                    { 
                        ListCustomers.Add(new CustomerInfo 
                        { 
                            Id = reader.GetInt32(0),    
                            Name = reader.GetString(1), 
                            Email = reader.GetString(2), 
                            Phone = reader.GetString(3) 
                        }); 
                    } 
                } 
            } 
            } 
            catch (Exception ex)            { 
                Console.WriteLine($"Error retrieving customers: {ex.Message}"); 
             
            }             
        } 
    }

    public class CustomerInfo
    {
        public int Id { get; set; } 
        public string? Name { get; set; } 
        public string? Email { get; set; } 
        public string? Phone { get; set; } 
    }
}
