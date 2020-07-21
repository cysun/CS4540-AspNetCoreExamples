using System;

namespace BCryptTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a password: ");
            var password = Console.ReadLine();
            Console.WriteLine("Hash: {0}", BCrypt.Net.BCrypt.HashPassword(password));
        }
    }
}
