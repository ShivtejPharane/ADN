//Do not force a class to implement unwanted methods.

/*public interface IWorker
{
    void Work();
    void Eat();
}

public class Robot : IWorker
{
    public void Work() {
        Console.WriteLine("Robot Works");
    }
    public void Eat() { } // Robot cannot eat
}


class Program
{
    static void Main(string[] args)
    {
        IWorker robot = new Robot();
        robot.Work();
        robot.Eat(); // This is not appropriate for Robot
    }
}*/

public interface IWork
{
    void Work();
}

public interface IEat
{
    void Eat();
}

public class Human : IWork, IEat
{
    public void Work() => Console.WriteLine("Human working");
    public void Eat() => Console.WriteLine("Human eating");
}

public class Robot : IWork
{
    public void Work() => Console.WriteLine("Robot working");
}

class Program
{
    static void Main()
    {
        IWork human = new Human();
        IWork robot = new Robot();

        human.Work();
        robot.Work();

        IEat eater = new Human();
        eater.Eat();
    }
}
