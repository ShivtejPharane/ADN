using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;

namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        static List<Student> students = new List<Student>
        {
            new Student { Id = 1, Name = "Shivani", Course = "CSE" },
            new Student { Id = 2, Name = "Rahul", Course = "IT" }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            students.Add(student);
            return Ok(student);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Student updatedStudent)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();

            student.Name = updatedStudent.Name;
            student.Course = updatedStudent.Course;

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound();

            students.Remove(student);
            return Ok();
        }
    }
}
