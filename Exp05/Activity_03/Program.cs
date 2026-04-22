using System;
using System.Threading.Tasks;

namespace EXP05
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Start");

            // Start both methods at the same time
            Task t1 = Method1();
            Task t2 = Method2();

            // Wait for both to complete
            await Task.WhenAll(t1, t2);

            Console.WriteLine("End");
        }

        static async Task Method1()
        {
            Console.WriteLine("Method1 Started");
            await Task.Delay(3000); // non-blocking delay
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