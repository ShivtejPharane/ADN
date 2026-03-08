using System;

class Program
{
    static void Main()
    {
        Func<int, int, int> add = (a, b) => a + b;

        Console.WriteLine(add(10, 20));
    }
}