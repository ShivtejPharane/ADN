# CRM Project - Viva Preparation Guide

This document is designed to help you prepare for your viva (oral exam). It explains the project in simple, easy-to-understand terms.

---

## 1. What is this project?

**Simple Answer:** It is a CRM (Customer Relationship Management) Web Application.
**Detailed Answer:** A CRM is software used by businesses to manage interactions with their customers, track sales opportunities, and organize their work. In this project, an Admin can log in and manage Customers, track potential sales (Leads), and organize their to-do lists (Tasks).

## 2. What Technologies were used?

You should memorize this stack! If the examiner asks "What did you use to build this?", say:

*   **Backend framework:** ASP.NET Core Razor Pages (using C#)
*   **Frontend UI:** HTML, CSS, and Bootstrap (for responsive design)
*   **Database:** MySQL (using the `MySql.Data.MySqlClient` library to connect to it)
*   **Data Access Method:** ADO.NET (Writing raw SQL queries like `SELECT`, `INSERT`, `UPDATE`, `DELETE` directly in C#)
*   **Authentication:** Cookie-based Authentication

## 3. How does the architecture work? (Razor Pages)

Unlike MVC (Model-View-Controller), this project uses **Razor Pages**. 
*   **The View (`.cshtml` files):** This is the HTML that the user sees. It uses "Razor syntax" (the `@` symbol) to inject C# code directly into the HTML.
*   **The PageModel (`.cshtml.cs` files):** This acts like the "brain" for that specific page. It handles the `OnGet()` method (what happens when the page loads) and `OnPost()` method (what happens when a form is submitted).

## 4. Key Modules of the Project

Explain these if asked "What features does your app have?":

1.  **Authentication (Login/Logout):** 
    *   Hardcoded login check (`admin` / `password`).
    *   Creates a secure "Cookie" so the system remembers the user is logged in.
2.  **Dashboard (Home Page):** 
    *   Shows a summary of total customers, total leads, and active tasks by querying the database using `COUNT(*)` SQL commands.
3.  **Customers Module:** 
    *   Allows the user to Create, Read, Update, and Delete (CRUD) customer records (Name, Email, Phone).
4.  **Leads Module:** 
    *   Tracks potential customers. Includes extra fields like Company name and Status (New, Contacted, Qualified, Lost).
5.  **Tasks Module:** 
    *   A to-do list for the admin. Includes Title, Description, Due Date, and a checkbox to mark it as completed.

## 5. Important Viva Questions & Answers

**Q1: How do you connect your application to the MySQL database?**
*Answer:* I use ADO.NET with the `MySqlConnection` object. I provide a connection string (`"Server=localhost;Port=3306;Database=dkte;Uid=root;Pwd=manager;"`) to establish the link.

**Q2: What is the difference between `ExecuteReader` and `ExecuteNonQuery`?**
*Answer:* 
*   `ExecuteReader` is used when we want to get data *back* from the database, like when using `SELECT` statements (e.g., viewing a list of customers).
*   `ExecuteNonQuery` is used when we are changing data but don't need rows returned, like with `INSERT`, `UPDATE`, or `DELETE` statements.

**Q3: How are you preventing SQL Injection?**
*Answer:* By using **Parameterized Queries**. Instead of directly pasting user input into the SQL string, I use placeholders like `@name` and add them using `command.Parameters.AddWithValue()`. This ensures the database treats the input strictly as data, not executable code.

**Q4: How does the login system work?**
*Answer:* It uses ASP.NET Core Cookie Authentication. When the user enters the correct username and password, the system creates a "Claim" (an identity record) and signs the user in, issuing a secure cookie to their browser. Unauthenticated users cannot access the `Customers`, `Leads`, or `Tasks` pages.

**Q5: Why did you use Razor Pages instead of MVC?**
*Answer:* Razor Pages makes building page-focused scenarios easier and more  (PageModel) and the View (HTML) are kept together, making it simpler to manage for a project of this size.organized. Instead of having views and controllers spread across different folders, the logic

---
*Good luck with your Viva! Just remember: the project is a simple C# Web App that reads and writes data to a MySQL database.*
