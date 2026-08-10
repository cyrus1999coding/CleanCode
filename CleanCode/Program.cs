using System.Runtime.CompilerServices;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>
            {
                new Order { Id =1, ProductName = "LapTop", Quantity = 2, Price = 1500 },
                new Order { Id =2, ProductName = "Phone", Quantity = 5, Price = 500 },
            };

            OrderPrinter printer = new OrderPrinter();
            printer.PrintOrderDetails(orders);

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

    public class OrderPrinter
    {
        public void PrintOrderDetails(List<Order> orders)
        {
            double totalPrice = 0;

            foreach (var order in orders)
            {
                if (order.Quantity > 0 && order.Price > 0)
                {
                    double total = order.Quantity * order.Price;
                    Console.WriteLine("Order ID: " + order.Id);
                    Console.WriteLine("Product: " + order.ProductName);
                    Console.WriteLine("Quantity: " + order.Quantity);
                    Console.WriteLine("Price: " + order.Price);
                    Console.WriteLine("Total: " + order.Price * order.Quantity);
                    Console.WriteLine("----------------------");

                    totalPrice += order.Quantity * order.Price;
                }
            }

            Console.WriteLine("Total Price: " + totalPrice);
        }
    }


}
