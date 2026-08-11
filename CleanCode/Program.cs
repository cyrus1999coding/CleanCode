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

            DiscountedInvoice discountedInvoice = new DiscountedInvoice { Amount= 100, Discount= 25};
            DiscountedBillingService discountedBillingService = new DiscountedBillingService();
            Console.WriteLine(discountedBillingService.CalculateTotal(discountedInvoice));

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
