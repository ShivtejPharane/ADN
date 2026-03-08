//Child class should not break the parent class behavior.

/*public class Rectangle
{
    public virtual int Width { get; set; }
    public virtual int Height { get; set; }
}

public class Square : Rectangle
{
    public override int Width { set { base.Width = base.Height = value; } }
    public override int Height { set { base.Width = base.Height = value; } }
}

class Program
{
    static void Main(string[] args)
    {
        Rectangle rect = new Rectangle { Width = 5, Height = 10 };
        Console.WriteLine($"Rectangle Area: {rect.Width * rect.Height}"); // Output: 50
        Rectangle square = new Square { Width = 5 };
        Console.WriteLine($"Square Area: {square.Width * square.Height}"); // Expected: 25, Actual: 25
    }
}*/

public abstract class Shape
{
    public abstract int Area();
}

public class Rectangle : Shape
{
    public int Width { get; set; }
    public int Height { get; set; }

    public override int Area()
    { 
        return (Width* Height);
    }
}

public class Square : Shape
{
    public int Side { get; set; }
    public override int Area()
    {
               return (Side * Side);

    }
}

class Program
{
    static void Main()
    {
        Shape s1 = new Rectangle { Width = 10, Height = 5 };
        Shape s2 = new Square { Side = 4 };

        Console.WriteLine(s1.Area());
        Console.WriteLine(s2.Area());
    }
}

// In this refactored version, both Rectangle and Square inherit from the Shape class and implement the Area method according to their specific formulas. This way, we adhere to the Liskov Substitution Principle, as any instance of Shape can be replaced with an instance of Rectangle or Square without altering the correctness of the program.

