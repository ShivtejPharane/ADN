using DataAnotation.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataAnotation.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Message = "Student data submitted successfully!";
                return View("Success", student);
            }

            return View(student);
        }

        public IActionResult Success(Student student)
        {
            return View(student);
        }
    }
}

