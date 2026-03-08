/*public class InvoiceService
{
    public void CreateInvoice()
    {
        Console.WriteLine("Invoice created");
    }

    public void SaveToDb()
    {
        Console.WriteLine("Invoice saved to DB");
    }

    public void SendEmail()
    {
        Console.WriteLine("Email sent to customer");
    }
}

 class Program
{
    static void Main(string[] args)
    {
        InvoiceService invoiceService = new InvoiceService();
        invoiceService.CreateInvoice();
        invoiceService.SaveToDb();
        invoiceService.SendEmail();
    }
}*/

//A class should have only one reason to change.

// Only creates invoice
public class InvoiceGenerator
{
    public void CreateInvoice()
    {
        Console.WriteLine("Invoice created");
    }
}

// Only saves to database
public class InvoiceRepository
{
    public void SaveToDb()
    {
        Console.WriteLine("Invoice saved to DB");
    }
}

// Only sends emails
public class EmailService
{
    public void SendEmail()
    {
        Console.WriteLine("Email sent");
    }
}

class Program
{
    static void Main()
    {
        var generator = new InvoiceGenerator();
        var repo = new InvoiceRepository();
        var mail = new EmailService();

        generator.CreateInvoice();
        repo.SaveToDb();
        mail.SendEmail();
    }
}
