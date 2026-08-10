using System.Runtime.CompilerServices;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrderProcessor orderProcessor = new OrderProcessor();

            Order order = new Order();

            if (orderProcessor.IsValid(order))
            {
                Console.WriteLine("Order is valid");
            }

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

            public bool IsValid(Order order)
            {
                // TODO: Validate order logic
                return false
            }

            public void SaveOrder(Order order)
            {
                // TODO: Save order logic
            }

            public void NotifyCustomer(Order order)
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
