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
            public const int MAX_CUSTOMERS = 100; 

            public int MyProperty { get; set; }

            private string lastCustomerName = "John";

            public string GetCustomerName(int customerId)
            {
                string customerName = "John Doe";

                return "";
            }
        }

    }
}
