//Classes should be open for extension, closed for modification
/*public class PaymentService
{
    public void Pay(string type)
    {
        if (type == "UPI")
            Console.WriteLine("Paid using UPI");
        else if (type == "Card")
            Console.WriteLine("Paid using Card");
    }
}

class Program
{
    static void Main(string[] args)
    {
        PaymentService paymentService = new PaymentService();
        paymentService.Pay("UPI");
        paymentService.Pay("Card");
    }
}*/
//Whenever new payment methods are added — you must modify this class.

public interface IPayment
{
    void Pay();
}

public class UpiPayment : IPayment
{
    public void Pay()
    {
        Console.WriteLine("Paid using UPI");
    }
}

public class CardPayment : IPayment
{
    public void Pay()
    {
        Console.WriteLine("Paid using Card");
    }
}

public class NetBanking : IPayment
{
    public void Pay()
    {
        Console.WriteLine("Paid using Net Banking");
    }

}
    public class PaymentService
{
    public void ProcessPayment(IPayment payment)
    {
        payment.Pay();
    }
}

class Program
{
    static void Main()
    {
        var service = new PaymentService();

        service.ProcessPayment(new UpiPayment());
        service.ProcessPayment(new CardPayment());
    }
}
