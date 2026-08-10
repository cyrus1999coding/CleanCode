# 004 Special convention for naming private fields

Addition thing when it comes to `private Fileds` 2 things :

```cs
namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.ReadKey();
        }

        class CustomerService
        {
            private string customerName = "JohnDoe"; ✅
            private string _customerName = "JohnDoe"; ✅
        }

    }
}
```

```cs
namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.ReadKey();
        }

        class CustomerService
        {
            //private string customerName = "JohnDoe";
            private string _customerName = "JohnDoe";

            public CustomerService(string customerName👈)
            {
                _customerName = customerName; 👈
            }
        }

    }
}
```

otherwise we need to use `this`

```cs
namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.ReadKey();
        }

        class CustomerService
        {
            private string customerName = "JohnDoe";
            //private string _customerName = "JohnDoe";

            public CustomerService(string customerName 👈)
            {
                this.customerName = customerName; 👈
            }
        }

    }
}
```