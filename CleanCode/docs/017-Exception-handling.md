# 017 Exception handling

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

        public void ReadFile(string filePath)
        { 
            string content = File.ReadAllText(filePath);
            Console.WriteLine(content);

            // File Not Found
            // Unauthorized Access
            // Any Other Exeption
        }
    }
}
```

- 🔑 Foe the `Web Developement` when we **Open up** `Files` on a `Server`  
  For example, We're dealing with the `System.IO namespace` almost  
  Every time, `Opening up Streams`, `Opening up Files` .
- 🔑⚠ There are so much that can go wrong under the hood .  

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

        public void ReadFile(string filePath)
        {

            try
            {
                string content = File.ReadAllText(filePath);
                Console.WriteLine(content);
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine("File not found: " + ex.message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Access denied: " + ex.message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Something went wrong" + ex.Message);
            }

            // File Not Found
            // Unauthorized Access
            // Any Other Exeption
        }
    }
}
```

👀🔑 ) For 🔑`HTTP Request` if we wanna buld a 🔑`Connection` to a **Database** becasue that really depends on other Factors .