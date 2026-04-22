using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CRMProject.Pages
{
    public class LogoutModel : PageModel
    {
        public void OnGet()
        {
            // If someone accidentally browses to /Logout, redirect them home
            Response.Redirect("/");
        }

        public async Task<IActionResult> OnPost()
        {
            // Clears the authentication cookie
            await HttpContext.SignOutAsync("MyCookieAuth");
            
            // Redirect back to home page
            return RedirectToPage("/Index");
        }
    }
}