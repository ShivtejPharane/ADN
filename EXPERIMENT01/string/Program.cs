namespace string1
    ;

internal class Program
{
    static void Main(string[] args)
    {
        string txt = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        Console.WriteLine("The length of the txt string is: " + txt.Length);

        string txt2 = "Hello World";
        Console.WriteLine(txt2.ToUpper());   // Outputs "HELLO WORLD"
        Console.WriteLine(txt2.ToLower());   // Outputs "hello world"

        string firstName = "om ";
        string lastName = "teke";
        string name = firstName + lastName;
        Console.WriteLine(name);

        //string interpolation
        string firstName1 = "om";
        string lastName2 = "teke";
        string name1 = $"My full name is: {firstName} {lastName}";
        Console.WriteLine(name1);

        string myString = "Hello";
        Console.WriteLine(myString[0]);  // Outputs "H"

        // Full name
        string name2 = "John Doe";

        // Location of the letter D
        int charPos = name2.IndexOf("D");
        Console.WriteLine(charPos);

        // Get last name
        string lastName3 = name2.Substring(charPos);

        // Print the result
        Console.WriteLine(lastName3);

        string t= "It\'s alright.";
        Console.WriteLine(t);







    }
}
