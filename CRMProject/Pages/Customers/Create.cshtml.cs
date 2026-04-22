using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace CRMProject.Pages.Customers
{
   public class Create : PageModel
{
    [BindProperty, Required(ErrorMessage = "Enter the name")]
    public string name { get; set; } = "";

    [BindProperty, Required(ErrorMessage = "Enter the email"),
     EmailAddress(ErrorMessage = "Invalid email format")]
    public string email { get; set; } = "";

    [BindProperty, Required(ErrorMessage = "Enter the phone number")]
    public string phone { get; set; } = "";

public void OnGet(int CustId)
{
    try
    {
        using (var connection = new MySqlConnection("Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=admin123;"))
        {
            connection.Open();
            var command = new MySqlCommand("SELECT * FROM customers WHERE id = @CustId", connection);
            command.Parameters.AddWithValue("@CustId", CustId);
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    CustId = reader.GetInt32(0);
                    name = reader.GetString(1);
                    email = reader.GetString(2);
                    phone = reader.GetString(3);
                }
                else
                {
                    Console.WriteLine("Customer not found." + CustId);
                    ModelState.AddModelError("", "Customer not found.");
                    return;
                }
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error retrieving customer details: {ex.Message}");
        ModelState.AddModelError("", ex.Message);
        return;
    }
}

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        try
        {
            using var connection = new MySqlConnection(
                "Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=manager;");

            connection.Open();

            string sql = "INSERT INTO customers (name, email, phone) VALUES (@name, @email, @phone)";
            using var command = new MySqlCommand(sql, connection);

            command.Parameters.AddWithValue("@name", name);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@phone", phone);

            command.ExecuteNonQuery();
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Error adding customer: " + ex.Message);
            return Page();
        }

        return RedirectToPage("Index");
    }
    public void post()
        {
            if(ModelState.IsValid)
            {
                try
                {
                    using var connection = new MySqlConnection("Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=manager;");
                    {
                        connection.Open();
                        string sql = "INSERT INTO customers (name, email, phone) VALUES (@name, @email, @phone)";
                        using var command = new MySqlCommand(sql, connection);
                        command.Parameters.AddWithValue("@name", name);//parameter commands to prevent SQL injection
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@phone", phone);
                        int i=command.ExecuteNonQuery();//returns the number of rows affected, we can use this to check if the insert was successful
                        if(i>0)
                        {
                            Console.WriteLine("Customer added successfully.");
                            ModelState.AddModelError("", "Customer added successfully.");
                            RedirectToPage("Index");
                        }
                        else
                        {
                            Console.WriteLine("Failed to add customer.");
                            ModelState.AddModelError("", "Failed to add customer.");
                        }
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error adding customer: {ex.Message}");
                    ModelState.AddModelError("", "Error adding customer: " + ex.Message);
                }
            }
            else
            {
                
            }
        }
}
}