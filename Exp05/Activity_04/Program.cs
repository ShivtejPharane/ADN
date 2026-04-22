using System;
using System.Threading.Tasks;

namespace EXP05
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Start");

            // Calling method that returns Task (no value)
            await DoWork();

            // Calling method that returns Task<T> (with value)
            int result = await GetData();
            Console.WriteLine("Result from GetData: " + result);

            Console.WriteLine("End");
        }

        // Method returning Task (no return value)
        static async Task DoWork()
        {
            Console.WriteLine("DoWork Started");
            await Task.Delay(2000); // simulate work
            Console.WriteLine("DoWork Completed");
        }

        // Method returning Task<T> (returns value)
        static async Task<int> GetData()
        {
            Console.WriteLine("GetData Started");
            await Task.Delay(3000); // simulate work
            Console.WriteLine("GetData Completed");
            return 100;
        }
    }
}