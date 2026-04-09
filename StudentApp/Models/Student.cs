// # MVC -> model view controller
// # model -> data
// # view -> user interface
// # controller -> logic
public class Student
{
    public string Name { get; set; }// property -> field + method
    public int Age { get; set; }
    public string Course { get; set; }
    public string Email { get; set; }
    
}
List <Student> students = new List<Student>()
{
    new Student(){ Name = "John", Age = 20, Course = "C#", Email = "john@example.com" },
    new Student(){ Name = "Jane", Age = 22, Course = "Java", Email = "jane@example.com" },
    new Student(){ Name = "Bob", Age = 21, Course = "Python", Email = "bob@example.com" }
};