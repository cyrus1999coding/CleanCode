# 006 Naming boolean values

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

        class OrderProcessor
        {
            private bool hasError = false; ✅
            private bool isValid = true; ✅
        }

    }
}
```
- `Properties`, `Fileds`, `Parameters`, `Methods` we always use **has** or **is** .