# 007 Meaning through naming

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

        class CustomerService
        {
            // ⚠ Not the best approach
            public void Save()
            { 
            
            }
        }

    }
}
```

```sc
using System.Runtime.CompilerServices;

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
            // ✅ Better way 

            public void SaveCustomer()
            { 
            
            }
            public void SaveCustomerName()
            { 
            
            }
        }

    }
}
```

🚀 : Using **Set**, **Is**, **Get**, **Has**, **Can** ↓

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

        class CustomerService
        {
            public void SetCustomerName() ✅
            { 
            }

            public bool HasErrors() ✅
            {
                return false;
            }

            public bool CanReceiveEmails() ✅
            {
                return false;
            }

        }

    }
}
```