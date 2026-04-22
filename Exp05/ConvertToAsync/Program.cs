using System;
using System.Threading.Tasks;

namespace EXP05
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Start");

            await Method1();
            await Method2();

            Console.WriteLine("End");
        }

        static async Task Method1()
        {
            Console.WriteLine("Method1 Started");
            await Task.Delay(3000);
            Console.WriteLine("Method1 Completed");
        }

        static async Task Method2()
        {
            Console.WriteLine("Method2 Started");
            await Task.Delay(2000);
            Console.WriteLine("Method2 Completed");
        }
    }
}