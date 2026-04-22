using Microsoft.AspNetCore.Mvc;

namespace CRM_MVC.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
