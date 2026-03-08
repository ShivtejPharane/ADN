using System;

class Program
{
    // Delegate declaration
    public delegate int Operation(int a, int b);

    static int Add(int a, int b)
    {
        return a + b;
    }

    static int Multiply(int a, int b)
    {
        return a * b;
    }
    static int Subtract(int a, int b)
    {
        return a - b;
    }
    static int Divide(int a, int b)
    {
        if (b == 0)
        {
            Console.WriteLine("Cannot divide by zero.");
            return 0;
        }
        return a / b;
    }

    static void Main()
    {
        Operation op;

        op = Add;
        Console.WriteLine("Addition : " + op(8, 19));

        op = Multiply;
        Console.WriteLine("Multiplication : " + op(8, 19));

        op = Subtract;
        Console.WriteLine("Subtraction : " + op(8, 19));
        op = Divide;
        Console.WriteLine("Division : " + op(8, 19));
     
    }
}