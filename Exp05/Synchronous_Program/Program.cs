

namespace EXP05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");

            Method1();
            Method2();

            Console.WriteLine("End");
        }

        static void Method1()
        {
            Console.WriteLine("Method1 Started");
            Thread.Sleep(3000); // blocks thread
            Console.WriteLine("Method1 Completed");
        }

        static void Method2()
        {
            Console.WriteLine("Method2 Started");
            Thread.Sleep(2000);
            Console.WriteLine("Method2 Completed");
        }
    }
}