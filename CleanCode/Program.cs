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
            private string customerName = "JohnDoe";
            //private string _customerName = "JohnDoe";

            public CustomerService(string customerName)
            {
                this.customerName = customerName;
            }
        }

    }
}
