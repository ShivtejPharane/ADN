using System;

class Program
{
    public delegate int Operation(int a, int b);

    static void Main()
    {
        Operation add = (a, b) => a + b;
        Operation multiply = (a, b) => a * b;
        Operation subtract = (a, b) => a - b;
        Operation divide = (a, b) => a / b;

        Console.WriteLine("Addition : " + add(8, 19));
        Console.WriteLine("Multiplication : " + multiply(8, 19));
        Console.WriteLine("Subtraction : " + subtract(19, 7));
        Console.WriteLine("Divide :" +divide(25,5));

    }
}