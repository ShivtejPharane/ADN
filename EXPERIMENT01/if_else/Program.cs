using System.Collections.Generic;

namespace if_else
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //            C# has the following conditional statements:

            //Use if to specify a block of code to be executed, if a specified condition is true
            //Use else to specify a block of code to be executed, if the same condition is false
            //Use else if to specify a new condition to test, if the first condition is false
            //Use switch to specify many alternative blocks of code to be executed

            int x = 20;
            int y = 18;
            if (x > y)
            {
                Console.WriteLine("x is greater than y");
            }

            int time = 20;
            if (time < 18)
            {
                Console.WriteLine("Good day.");
            }
            else
            {
                Console.WriteLine("Good evening.");
            }
            // Outputs "Good evening."

           
int time2 = 22;
            if (time2 < 10)
            {
                Console.WriteLine("Good morning.");
            }
            else if (time2 < 20)
            {
                Console.WriteLine("Good day.");
            }
            else
            {
                Console.WriteLine("Good evening.");
            }
            // Outputs "Good evening."

            int time3 = 20;
            string result = (time < 18) ? "Good day." : "Good evening.";
            Console.WriteLine(result);
        }
    }
}
