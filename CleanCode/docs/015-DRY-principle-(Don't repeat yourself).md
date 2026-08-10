# 015 DRY principle (Don't repeat yourself)

```cs
using System.Runtime.CompilerServices;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DiscountCalculator discountCalculator = new DiscountCalculator();

            double regularCustomerDiscount = DiscountCalculator.CalculateDiscountForReqularCustomer(1200);
            Console.WriteLine($"Regular Customer Discount : {regularCustomerDiscount}");

            double premiumCustomerDiscount = discountCalculator.CalculateDiscountForPremiumCustomer(800);
            Console.WriteLine($"Primium Customer Discount : {premiumCustomerDiscount}");

            double employeeCustomerDiscount = discountCalculator.CalculateDiscountForEmployeeCustomer(1500);
            Console.WriteLine($"Employee Customer Discount : {employeeCustomerDiscount}");
        }
    }

    public class DiscountCalculator
    {
        public double CalculateDiscountForRegularCustomer(double totalAmount)
        {
            if (totalAmount > 1000)
            {
                return totalAmount * 0.1; // 10% discount
            }
            else
            {
                return totalAmount * 0.05; // 5% discount
            }
        }

        public double CalculateDiscountForPrimiumCustomer(double totalAmount)
        {
            if (totalAmount > 1000)
            {
                return totalAmount * 0.15; // 15% discount
            }
            else
            {
                return totalAmount * 0.1; // 10% discount
            }
        }

        public double CalculateDiscountForEmployeeCustomer(double totalAmount)
        {
            if (totalAmount > 1000)
            {
                return totalAmount * 0.2; // 20% discount
            }
            else
            {
                return totalAmount * 0.15; // 15% discount
            }
        }
    }
}
```

Each of these `Methods` nearly has the same Statements .  
A lot of Duplication .

Let's apply the `DRY Principle` ↓

🔑 :  
We have 3 `Methods` or 3 different kinda of `Custoemrs` a good `Data Structure` would be an `Enum` because we  
Could switch for different Customer Types .

```cs
using System.Runtime.CompilerServices;

namespace CleanCode
{
    👇 // Usually it goes to its own file
    public enum CustomerType
    {
        Rqgular,
        Premium,
        Employee
    }
    👆
    internal class Program
    {
        static void Main(string[] args)
        {
            DiscountCalculator discountCalculator = new DiscountCalculator();

            double regularCustomerDiscount = DiscountCalculator.CalculateDiscountForReqularCustomer(1200);
            Console.WriteLine($"Regular Customer Discount : {regularCustomerDiscount}");

            double premiumCustomerDiscount = discountCalculator.CalculateDiscountForPremiumCustomer(800);
            Console.WriteLine($"Primium Customer Discount : {premiumCustomerDiscount}");

            double employeeCustomerDiscount = discountCalculator.CalculateDiscountForEmployeeCustomer(1500);
            Console.WriteLine($"Employee Customer Discount : {employeeCustomerDiscount}");
        }
    }

    public class DiscountCalculator
    {
        👇
        public double CalculateDiscount(CustomerType customerType, double totalAmount)
        {
            double discount = 0;

            switch (customerType)
        }
        👆
        public double CalculateDiscountForRegularCustomer(double totalAmount)
        {
            if (totalAmount > 1000)
            {
                return totalAmount * 0.1; // 10% discount
            }
            else
            {
                return totalAmount * 0.05; // 5% discount
            }
        }

        public double CalculateDiscountForPrimiumCustomer(double totalAmount)
        {
            if (totalAmount > 1000)
            {
                return totalAmount * 0.15; // 15% discount
            }
            else
            {
                return totalAmount * 0.1; // 10% discount
            }
        }

        public double CalculateDiscountForEmployeeCustomer(double totalAmount)
        {
            if (totalAmount > 1000)
            {
                return totalAmount * 0.2; // 20% discount
            }
            else
            {
                return totalAmount * 0.15; // 15% discount
            }
        }
    }
}
```

We'll also 🔑`const` 

```cs
using System.Runtime.CompilerServices;

namespace CleanCode
{
    public enum CustomerType
    {
        Rqgular,
        Premium,
        Employee
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            DiscountCalculator discountCalculator = new DiscountCalculator();

            double regularCustomerDiscount = DiscountCalculator.CalculateDiscountForReqularCustomer(1200);
            Console.WriteLine($"Regular Customer Discount : {regularCustomerDiscount}");

            double premiumCustomerDiscount = discountCalculator.CalculateDiscountForPremiumCustomer(800);
            Console.WriteLine($"Primium Customer Discount : {premiumCustomerDiscount}");

            double employeeCustomerDiscount = discountCalculator.CalculateDiscountForEmployeeCustomer(1500);
            Console.WriteLine($"Employee Customer Discount : {employeeCustomerDiscount}");
        }
    }

    public class DiscountCalculator
    {
        👇
        private const int DISCOUNT_THRESHOLD = 1000;

        public double CalculateDiscount(CustomerType customerType, double totalAmount)
        {
            double discount = 0;

            switch (customerType)
            {
                case CustomerType.Rqgular:
                    discount = totalAmount > DISCOUNT_THRESHOLD ? 0.1 : 0.05;
                    break; case 
                case CustomerType.Premium:
                    discount = totalAmount > DISCOUNT_THRESHOLD ? 0.15 : 0.10;
                    break;
                case CustomerType.Premium:
                    discount = totalAmount > DISCOUNT_THRESHOLD ? 0.20 : 0.15;
                    break;
            }

            return discount
        }
        👆

    }
}
```

```cs
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
```

```console
Regular Customer Discount : 0.1
Premium Customer Discount : 0.1
Employee Customer Discount : 0.2
```