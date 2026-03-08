using System;
using System.Linq;

class Program
{
    static void Main()
    {
        int[] numbers = { 10, 20, 30, 40, 50 };

        var result = numbers.Where(n => n > 25);

        foreach (var n in result)
        {
            Console.WriteLine(n);
        }
    }
}