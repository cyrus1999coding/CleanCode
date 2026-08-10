using System.Runtime.CompilerServices;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.ReadKey();
        }

        class CustomerService
        {
            public void SetCustomerName()
            { 
            }

            public bool HasErrors()
            {
                return false;
            }

            public bool CanReceiveEmails()
            {
                return false;
            }

        }

    }
}
