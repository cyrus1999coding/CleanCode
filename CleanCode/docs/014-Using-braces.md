# 014 Using braces

Consistant use of braces ↓

```cs
using System.Runtime.CompilerServices;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrderProcessor orderProcessor = new OrderProcessor();

            Order order = new Order();
            👇⚠
            if(orderProcessor.IsValid(order))
                Console.WriteLine("Order is valid");
            👆
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
```

This is a bad practice when it comees to Clean Code principles .
✅ It's ok  
🚀 But the Clean Code says that we still need to use `{}` even if we have Single Statement .

```cs
using System.Runtime.CompilerServices;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OrderProcessor orderProcessor = new OrderProcessor();

            Order order = new Order();
            👇🚀
            if (orderProcessor.IsValid(order))
            {
                Console.WriteLine("Order is valid");
            }
            👆
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
```
This works for `If Statements`, `For Loops` and whatever .