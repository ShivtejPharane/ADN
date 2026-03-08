//High - level modules must depend on abstraction, not concrete classes.

/*public class Notification
{
    private Email email = new Email();  // tightly coupled

    public void Send()
    {
        email.SendEmail();
    }
}

public class Email
{
    public void SendEmail() 
    { 
        Console.WriteLine("Email sent");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Notification notification = new Notification();
        notification.Send();
    }
}*/

public interface IMessage
{
    void SendMessage();
}
public class EmailMessage : IMessage
{
    public void SendMessage() 
    {
        Console.WriteLine("Email sent"); 
    }
}

public class SmsMessage : IMessage
{
    public void SendMessage()  
    {
        Console.WriteLine("SMS sent");
    }
}


public class Notification
{
    private readonly IMessage _message;

    public Notification(IMessage message)
    {
        _message = message;
    }

    public void Notify()
    {
        _message.SendMessage();
    }
}

class Program
{
    static void Main()
    {
        Notification n1 = new Notification(new EmailMessage());
        n1.Notify();

        Notification n2 = new Notification(new SmsMessage());
        n2.Notify();
    }
}

