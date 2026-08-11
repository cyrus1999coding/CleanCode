using System.Runtime.CompilerServices;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.ReadKey();
        }
    }

    public class Order
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }

    public class OrderService
    {
        private List<Order> orders = new List<Order>();
        private OrderLogger orderLogger = new OrderLogger();
        private OrderNotifier orderNotifier = new OrderNotifier();

        public void AddOrder(Order order)
        {
            orders.Add(order);
            orderLogger.LogOrder(order);
            orderNotifier.NotifyCustomer(order);
        }


    }

    public class OrderLogger
    {
        public void LogOrder(Order order)
        {
            // Log the order to a File 
            Console.WriteLine($"Order {order.Id} logged.");
        }

    }

    public class OrderNotifier
    {
        public void NotifyCustomer(Order order)
        {
            // Send a notification to the customer
            Console.WriteLine($"Customer notified for order {order.Id}.");
        }
    }

}
