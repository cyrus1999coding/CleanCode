# 011 Formatting code

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

        public class Customer
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            public void PrintFullName()
            {
                Console.WriteLine($"{FirstName} {LastName}");
            }
        }
    }
}
```

Add linebreak between `Properties` and `Methods`, `Constructor`, `Fields` .