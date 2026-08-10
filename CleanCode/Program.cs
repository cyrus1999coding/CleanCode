using System.Runtime.CompilerServices;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.ReadKey();
        }

        public class OrderProcessor
        {
            public void ProcessOrder(Order order)
            {
                if (IsValid(order))
                {
                    SaveOrder(order);
                    NotifyCustomer(order);
                }
            }

            private bool IsValid(Order order)
            {                 
                // TODO: Validate order logic
                return false
            }

            private void SaveOrder(Order order)
            {
                // TODO: Save order logic
            }

            private void NotifyCustomer(Order order)
            {
                // TODO: Save customer logic
            }
        }

        public class Order
        {
            public int Quantity { get; set; }
        }

    }
}
