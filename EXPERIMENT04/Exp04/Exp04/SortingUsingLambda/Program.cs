using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int> { 5, 2, 8, 1, 4 };

        numbers.Sort((a, b) => a.CompareTo(b));

        foreach (int num in numbers)
        {
            Console.WriteLine(num);
        }
    }
}