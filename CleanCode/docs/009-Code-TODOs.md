# 009 Code TODOs

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

        public class MathUtils
        {
            public static int BinarySearch(int[] sortedArray, int target)
            {

                return -1; 👈
            }
        }

    }
}
```

Unfinished work better to do it this way ↓

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

        public class MathUtils
        {
            /// <summary>
            /// TODO: Implement the binary search algoritm
            /// </summary>
            /// <param name="sortedArray"></param>
            /// <param name="target"></param>
            /// <returns></returns>
            public static int BinarySearch(int[] sortedArray, int target)
            {

                return -1;
            }
        }

    }
}
```

And from  
*View → Task List *  
We'll be able to see al the parts of our code that use it `TODO Comment` ↓

Priority	Description	Project	File	Line
Normal	TODO: Implement the binary search algoritm	CleanCode	D:\cprojects\20 Clean Code\CleanCode\CleanCode\Program.cs	16
