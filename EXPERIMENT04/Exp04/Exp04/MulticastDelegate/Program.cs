using System;

class Program
{
    public delegate void ShowMessage();

    static void Message1()
    {
        Console.WriteLine("Hello");
    }

    static void Message2()
    {
        Console.WriteLine("Welcome");
    }

    static void Main()
    {
        ShowMessage msg;

        msg = Message1;
        msg += Message2;   // multicast

        msg();
    }
}