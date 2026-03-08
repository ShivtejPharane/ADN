namespace variable_declaration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "om";
            Console.WriteLine(name);

            int myNum;
            myNum = 15;
            Console.WriteLine(myNum);

            int num = 15;
            num = 20;
            Console.WriteLine(num);

            int myNum1 = 5;
            double myDoubleNum = 5.99D;
            char myLetter = 'D';
            bool myBool = true;
            string myText = "Hello";

            Console.WriteLine(myNum1);
            Console.WriteLine(myDoubleNum);
            Console.WriteLine(myLetter);
            Console.WriteLine(myBool);
            Console.WriteLine(myText);

            int x = 5, y = 6, z = 50;
            Console.WriteLine(x + y + z);
        }
    }
}
