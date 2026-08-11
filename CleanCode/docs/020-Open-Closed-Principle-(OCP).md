# 020 Open-Closed Principle (OCP)

```cs
using System.Runtime.CompilerServices;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Invoice invoice = new Invoice { Amount = 100 };
            BillingService billingService = new BillingService();
            double total = billingService.CalculateTotal(invoice);
            Console.WriteLine($"Total: {total}");

            Console.ReadKey();
        }
    }

    public class Invoice
    {
        public double Amount { get; set; }
    }

    public class BillingService
    {
        public double CalculateTotal(Invoice invoice)
        {
            // Base implementation for calculating total
            return invoice.Amount;
        }
    }
}
```

Open-Closed Principle (OCP) gives us a way that how we should extend our functionality for our software .  

💚 : App is well desging right now 
What will you do if we should create another Type of Invoice ❔  
👀 ) For example *DiscountedInvoice* ❔  
💡 :  
`Open-Closed` says that :  
⛔ we do not **Modify** the existing Logic .  
✅ Instead of **Modify** the existing alogorithms *public class Invoice* and *public class BillingService*  
We want to create new `Classes` and **Extend** the functionality and rely on what's working already .

```cs
using System.Runtime.CompilerServices;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Invoice invoice = new Invoice { Amount = 100 };
            BillingService billingService = new BillingService();
            double total = billingService.CalculateTotal(invoice);
            Console.WriteLine($"Total: {total}");

            Console.ReadKey();
        }
    }

    public class Invoice
    {
        public double Amount { get; set; }
    }
    👇
    public class DiscountedInvoice : Invoice  👈
    {
        public double Discount { get; set; }
    }
    👆
    public class BillingService
    {
        public virtual 👈 double CalculateTotal(Invoice invoice)
        {
            // Base implementation for calculating total
            return invoice.Amount;
        }
    }
    👇
    public class DiscountedBillingService : BillingService 👈
    {
            if (invoice is DiscountedInvoice discountedInvoice)
            {
                return discountedInvoice.Amount - discountedInvoice.Discount;
            }

            return base.CalculateTotal(invoice);
    }
    👆
}
```
🔑 As we can see we not **Modified** any of the existing logic related to the *BillingService*  
And the *Invoice* `Classes` instead we used our Open-Closed principle and Extended our functionality .

Let's test our program .

```cs
using System.Runtime.CompilerServices;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Invoice invoice = new Invoice { Amount = 100 };
            BillingService billingService = new BillingService();
            double total = billingService.CalculateTotal(invoice);
            Console.WriteLine($"Total: {total}");

            DiscountedInvoice discountedInvoice = new DiscountedInvoice { Amount= 100, Discount= 25}; 👈
            DiscountedBillingService discountedBillingService = new DiscountedBillingService(); 👈
            Console.WriteLine(discountedBillingService.CalculateTotal(discountedInvoice)); 👈

            Console.ReadKey();
        }
    }

    public class Invoice
    {
        public double Amount { get; set; }
    }

    public class DiscountedInvoice : Invoice 
    {
        public double Discount { get; set; }
    }

    public class BillingService
    {
        public virtual double CalculateTotal(Invoice invoice)
        {
            // Base implementation for calculating total
            return invoice.Amount;
        }
    }

    public class DiscountedBillingService : BillingService
    {
        public override double CalculateTotal(Invoice invoice)
        {
            if (invoice is DiscountedInvoice discountedInvoice)
            {
                return discountedInvoice.Amount - discountedInvoice.Discount;
            }

            return base.CalculateTotal(invoice);
        }
    }

}
```

```console
Total: 100
75 👈
```