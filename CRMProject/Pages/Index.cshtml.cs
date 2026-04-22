using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRMProject.Pages;

public class IndexModel : PageModel
{
    [BindProperty]
    public string Username { get; set; } = "";

    [BindProperty]
    public string Password { get; set; } = "";

    public string ErrorMessage { get; set; } = "";

    public void OnGet()
    {
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
            
            // Redirect to Customers page after successful login
            return RedirectToPage("/Customers/Index"); 
        }

        // If it fails, show an error
        ErrorMessage = "Invalid username or password";
        return Page();
    }
}