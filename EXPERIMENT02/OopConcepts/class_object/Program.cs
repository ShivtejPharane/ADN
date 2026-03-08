/*class Car
{
    string color = "red";

    static void Main(string[] args)
    {
        Car myObj = new Car();
        Console.WriteLine(myObj.color);
    }
}
*/

//Multiple Objects

/*class Car
{
    string color = "red";
    string brand = "Mustang";
    static void Main(string[] args)
    {
        Car myObj1 = new Car();
        Car myObj2 = new Car();
        Console.WriteLine(myObj1.color);
        Console.WriteLine(myObj2.brand);
    }
}*/

//Class Members

class Car
{
    string model;
    string color;
    int year;

    static void Main(string[] args)
    {
        Car Ford = new Car();
        Ford.model = "Mustang";
        Ford.color = "red";
        Ford.year = 1969;

        Car Opel = new Car();
        Opel.model = "Astra";
        Opel.color = "white";
        Opel.year = 2005;

        Console.WriteLine(Ford.model);
        Console.WriteLine(Opel.model);
    }
}