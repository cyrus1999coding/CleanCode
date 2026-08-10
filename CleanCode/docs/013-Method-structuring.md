# 013 Method structuring

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

        public class OrderProcessor
        {
            public void ProcessOrder(Order order)
            {
                // Validate order
                if (order.Quantity > 0)
                {
                    // Save order
                    Console.WriteLine("Order saved");

                    // Notify customer
                    Console.WriteLine("Customer notified");
                }
            }
        }

        public class Order
        { 
            public int Quantity { get; set; }
        }

    }
}
```

🔑 This looks like Valid but the thing is that we should  
Write down entire Logic inside the *OrderProcessor* split it into `3 Separate Methods` .  
For each :
- Validate order
- Save order
- Notify customer

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

        public class OrderProcessor
        {
            public void ProcessOrder(Order order)
            {
                ValidateOrder(order); 👈
                SaveOrder(order); 👈
                NotifyCustomer(order); 👈
            }

            private void ValidateOrder(Order order)
            { 
                // TODO: Validate order logic
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
```

Now we 🔑`Encapsulated` the Entire Logic into separate Methods that we cna use everywhere .

Or :

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

        public class OrderProcessor
        {
            public void ProcessOrder(Order order)
            {
                👇
                if (IsValid(order))
                {
                    SaveOrder(order);
                    NotifyCustomer(order);
                }
                👆
            }

            private bool 👉IsValid(Order order)
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
```