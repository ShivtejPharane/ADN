using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using LoggingCachingDemo.Models;

namespace LoggingCachingDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly IMemoryCache _cache;

        public StudentController(ILogger<StudentController> logger,            IMemoryCache cache)
        {
            _logger = logger;
            _cache = cache;
        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            string cacheKey = "studentList";

            if (!_cache.TryGetValue(cacheKey, out List<Student> students))
            {
                _logger.LogInformation("Data from DATABASE (Simulated)");

                students = new List<Student>
                {
                    new Student { Id = 1, Name = "Shivani" },
                    new Student { Id = 2, Name = "Rahul" }
                };

                var options = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(30));

                _cache.Set(cacheKey, students, options);
            }
            else
            {
                _logger.LogInformation("Data from CACHE");
            }

            return Ok(students);
        }
    }
}
