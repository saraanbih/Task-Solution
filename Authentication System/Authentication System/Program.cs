using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using Microsoft.Data.SqlClient;
using System.Text;

class Program
{
    // This is a string to connect with the database
    static string ConnectionString = "Server=DESKTOP-O0I95CA;Database=UserAuth;User Id=sa;Password=sa123456;TrustServerCertificate=True;";

    // This is an email pattern to check that the email is valid
    static string EmailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

    // Function to check if email is valid or not
    static bool IsValid(string email)
    {
        return Regex.IsMatch(email, EmailPattern);
    }

    // Hash Password using SHA256 (without salt)
    static string HashPassword(string password)
    {
        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashBytes = sha256.ComputeHash(passwordBytes);
            return Convert.ToBase64String(hashBytes);
        }
    }

    // This function checks if the email already exists in the database
    static bool IsEmailExist(string Email)
    {
        using (SqlConnection Connection = new SqlConnection(ConnectionString))
        {
            try
            {
                Connection.Open();
                string query = "SELECT COUNT(*) FROM Users WHERE email = @Email";

                using (SqlCommand cmd = new SqlCommand(query, Connection))
                {
                    cmd.Parameters.AddWithValue("@Email", Email);

                    int count = (int)cmd.ExecuteScalar(); 

                    if (count > 0)
                        return true; 
                    else
                        return false; 
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }
    }


    static void Main(string[] args)
    {
        Console.WriteLine("Welcome To Registration and Login :-)");

        Console.WriteLine("Choose 1 for Register, 2 for Login, any character for Exit");
        Console.WriteLine("\n1. Register\n2. Login");
        int choice;

        if (!int.TryParse(Console.ReadLine(), out choice)) return;

        if (choice == 1)
        {
            if (Register())
                Console.WriteLine("You have registered successfully!");
            else
                Console.WriteLine("Sorry, something went wrong!");
        }
        else if (choice == 2)
        {
            if (Login())
                Console.WriteLine("You have logged in successfully!");
            else
                Console.WriteLine("Invalid email or password!");
        }
        else
            return;

        Console.ReadKey();
    }

    // This function is for users who will register for the first time
    static bool Register()
    {
        Console.WriteLine("Please enter User Name: ");
        string userName = Console.ReadLine();

        Console.WriteLine("Please enter Email (Valid Email): ");
        string email = Console.ReadLine();

        int valid = 1;
        while (!IsValid(email))
        {
            valid++;
            Console.WriteLine("Please enter a valid email!");
            email = Console.ReadLine();
            if (valid == 3) return false;
        }

        // Check if the email is already registered
        valid = 1;
        while (IsEmailExist(email)) { 
        
            valid++;
            Console.WriteLine("The email is already registered. Please use a different email:");
            email = Console.ReadLine();
            if (valid == 3) return false;
        }

        Console.WriteLine("Please enter Password: ");
        string password = Console.ReadLine();
        string hashedPassword = HashPassword(password);

        // We are going to connect to the database to register the user
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            try
            {
                connection.Open();
                string query = "INSERT INTO Users (username, email, password) VALUES (@UserName, @Email, @HashedPassword)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@HashedPassword", hashedPassword);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                return false;
            }
        }

        return true;
    }

    // This function is for users who already have an account
    static bool Login()
    {
        Console.Write("Enter email: ");
        string email = Console.ReadLine();

        Console.Write("Enter password: ");
        string password = Console.ReadLine();
        string hashedPassword = HashPassword(password);

        // We are going to connect to the database to search for the user
        using (SqlConnection connection = new SqlConnection(ConnectionString))
        {
            try
            {
                connection.Open();
                string query = "SELECT password FROM Users WHERE email = @Email";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Email", email);

                    var result = cmd.ExecuteScalar();
                    if (result == null || result.ToString() != hashedPassword)
                        return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        return true;
    }
}
