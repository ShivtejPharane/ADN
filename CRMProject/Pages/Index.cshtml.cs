using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MySql.Data.MySqlClient;

namespace CRMProject.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public string Username { get; set; } = "";

    [BindProperty]
    public string Password { get; set; } = "";

    public string ErrorMessage { get; set; } = "";

    public int TotalCustomers { get; set; } = 0;
    public int TotalLeads { get; set; } = 0;
    public int ActiveTasks { get; set; } = 0;

    public void OnGet()
    {
        if (User.Identity != null && User.Identity.IsAuthenticated)
        {
            try
            {
                using var connection = new MySqlConnection("Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=manager;");
                connection.Open();

                using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM customers", connection))
                {
                    TotalCustomers = Convert.ToInt32(cmd.ExecuteScalar());
                }
                
                using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM leads", connection))
                {
                    TotalLeads = Convert.ToInt32(cmd.ExecuteScalar());
                }

                using (var cmd = new MySqlCommand("SELECT COUNT(*) FROM tasks WHERE is_completed = 0", connection))
                {
                    ActiveTasks = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving dashboard data: {ex.Message}");
            }
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {
        // Simple hardcoded check. 
        if (Username == "admin" && Password == "password")
        {
            // 1. Create the security claims
            var claims = new List<Claim> {
                new Claim(ClaimTypes.Name, "Admin")
            };

            // 2. Create the identity and principal
            var identity = new ClaimsIdentity(claims, "MyCookieAuth");
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

            // 3. Sign in the user (this creates the cookie)
            await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
            
            // Redirect to Dashboard page after successful login
            return RedirectToPage("/Index"); 
        }

        // If it fails, show an error
        ErrorMessage = "Invalid username or password";
        return Page();
    }
}