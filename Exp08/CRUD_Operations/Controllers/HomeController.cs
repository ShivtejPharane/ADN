using CRUD_Operations.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUD_Operations.Controllers
{
    public class HomeController : Controller
    {
        SbContext sb = new SbContext();



        public IActionResult Index()
        {
            List<Student> slist = sb.Students.ToList();
            return View(slist);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult AfterCreate(Student s)
        {
            sb.Students.Add(s);
            sb.SaveChanges();
            return Redirect("/Home/Index");
        }
        public IActionResult Edit(int id)
        {
            Student s1 = sb.Students.Find(id);
            return View(s1);
        }
        public IActionResult AfterEdit(Student s)
        {
            Student s1 = sb.Students.Find(s.Id);
            s1.Name = s.Name;
            s1.CourseName = s.CourseName;
            sb.SaveChanges();
            return Redirect("/Home/Index");
        }

        public IActionResult Delete(int id)
        {
            Student s1 = sb.Students.Find(id);
            return View(s1);
        }

        public IActionResult AfterDelete(Student s)
        {
            Student s1 = sb.Students.Find(s.Id);
            sb.Students.Remove(s1);
            sb.SaveChanges();
            return Redirect("/Home/Index");

        }
    }
}
