# 002 Clarity and precision in naming

⛔ :  

```cs
namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0; ⛔
            string s = "John"; ⛔
        }
    }
}
```

✅ :

```cs
namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int studentCount = 100; ✅
           string studentName = "John"; ✅
        }
    }
}
```