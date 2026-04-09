//controller is brain of the application
// it handdle user request and return response
public class StudentController : controllers
{
    public IActionResult Index()
    {
        return View(students);
    }
}