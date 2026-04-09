using Microsoft.AspNetCore.Mvc;

namespace CRMAdvanced.Controllers;

public class CustomerController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}