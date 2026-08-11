# 019 Single Responsibility Principle (SRP)

Focused on **creating** `Classes` or what `Classes` should do


```cs
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

        public void AddOrder(Order order)
        {
            orders.Add(order);
            LogOrder(order);
            NotifyCustomer(order);
        }
        private void LogOrder(Order order)
        {
            // Log the order to a File 
            Console.WriteLine($"Order {order.Id} logged.");
        }

        private void NotifyCustomer(Order order)
        {
            // Send a notification to the customer
            Console.WriteLine($"Customer notified for order {order.Id}.");
        }
    }
}
```
💚 : Good thing about this code is *NotifyCustomer*, *LogOrder*, *AddOrder* already separated ✅ .
❤ : However the Single Responsibility Pattern says 
> 1 Class should only have 1 **Responsibility** ↓

In *OrderService* we have Muliple **Responsibilities** *NotifyCustomer*, *LogOrder*, *AddOrder* And those  
Are entirely different .  
*Logging* has nothing to do with managing like *Adding* or *Removing* them not does *Notifying* has any responsibility  
or is related to the *Order* .

So we would have to split up the *OrderService* into Multiple 🔑`Sub-Classes` so that each `Class` only has  
One Responsibility :
- One Class handle the Orders → Adding, Removing and ...
- One Class that handle the → Notification  
- One Class that handle the → Logging  

So :

```cs
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

        public void AddOrder(Order order)
        {
            orders.Add(order);
            LogOrder(order);
            NotifyCustomer(order);
        }


    }
    👇
    public class OrderLogger
    {
        private void LogOrder(Order order)
        {
            // Log the order to a File 
            Console.WriteLine($"Order {order.Id} logged.");
        }

    }
    👆
    👇
    public class OrderNotifier
    {
        private void NotifyCustomer(Order order)
        {
            // Send a notification to the customer
            Console.WriteLine($"Customer notified for order {order.Id}.");
        }
    }
    👆
}
```

```cs
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
        private OrderLogger orderLogger = new OrderLogger(); 👈
        private OrderNotifier orderNotifier = new OrderNotifier(); 👈

        public void AddOrder(Order order)
        {
            orders.Add(order);
            orderLogger.LogOrder(order); 👈
            orderNotifier.NotifyCustomer(order); 👈
        }


    }

    public👈 class OrderLogger
    {
        public void LogOrder(Order order)
        {
            // Log the order to a File 
            Console.WriteLine($"Order {order.Id} logged.");
        }

    }

    public👈 class OrderNotifier
    {
        public void NotifyCustomer(Order order)
        {
            // Send a notification to the customer
            Console.WriteLine($"Customer notified for order {order.Id}.");
        }
    }

}
```

🔑 Notice that the *OrderService* is the main part for handling our Orders, So  
🔑🔑 In there (*OrderService*) is ok to create `Instances` of other `Classes` which kind of like add 🔑`Side Effects` like *Logging* and *Notifying*,  
When we **Access**, **Add**, **Remove**, **Update** our Orders .


