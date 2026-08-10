using System.Runtime.CompilerServices;

namespace CleanCode
{
    public enum CustomerType
    {
        Regular,
        Premium,
        Employee
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            double regularCustomerDiscount =
                DiscountCalculator.CalculateDiscount(CustomerType.Regular, 1200);

            Console.WriteLine($"Regular Customer Discount : {regularCustomerDiscount}");

            double premiumCustomerDiscount =
                DiscountCalculator.CalculateDiscount(CustomerType.Premium, 800);

            Console.WriteLine($"Premium Customer Discount : {premiumCustomerDiscount}");

            double employeeCustomerDiscount =
                DiscountCalculator.CalculateDiscount(CustomerType.Employee, 1500);

            Console.WriteLine($"Employee Customer Discount : {employeeCustomerDiscount}");

            Console.ReadKey();
        }
    }

    public class DiscountCalculator
    {
        private const int DISCOUNT_THRESHOLD = 1000;

        public static double CalculateDiscount(
            CustomerType customerType,
            double totalAmount)
        {
            double discount = 0;

            switch (customerType)
            {
                case CustomerType.Regular:
                    discount = totalAmount > DISCOUNT_THRESHOLD ? 0.1 : 0.05;
                    break;

                case CustomerType.Premium:
                    discount = totalAmount > DISCOUNT_THRESHOLD ? 0.15 : 0.10;
                    break;

                case CustomerType.Employee:
                    discount = totalAmount > DISCOUNT_THRESHOLD ? 0.20 : 0.15;
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(customerType));
            }

            return discount;
        }
    }
}
