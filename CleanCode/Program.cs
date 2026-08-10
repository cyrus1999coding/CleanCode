using CleanCode.Models;
using CleanCode.Services;
using System.Runtime.CompilerServices;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerService customerService = new CustomerService();
            Customer customer = new Customer();

            Console.ReadKey();
        }


    }
}
