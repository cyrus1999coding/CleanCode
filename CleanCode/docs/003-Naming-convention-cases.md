# 003 Naming convention cases

`camelCase`, `PascalCase`, `ALLCAPSCASE` .

✅ :

```
namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args) // 👈 PascalCase
        {
            
            Console.ReadKey();
        }

        class CustomerService
        {
            public const int MAX_CUSTOMERS = 100; //👈 ALLCAPSCASE

            public int MyProperty { get; set; } //👈 PascalCase

            private string lastCustomerName = "John"; //👈 camelCase

           public string GetCustomerName👈 PascalCase(int customerId👈 camelCase) 
            {
                string customerName = "John Doe"; //👈 camelCase

                return "";
            }
        }

    }
}

```

1. `PascalCase` :

For `Interfaces`, `Classes`, `public Properties`, `Methods`

2. `camelCase` :  

For `private Fields`, `Local Variables`,  If we have a `Property` inisde of a `Method`

3. `ALLCAPSCASE` :

For `const`s