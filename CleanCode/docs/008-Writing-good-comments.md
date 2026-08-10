# 008 Writing good comments

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

        /// <summary>
        /// **Because**👈 Improve the performance for large Datasets 
        /// </summary>
        /// <param name="sortedArray"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public class MathUtils
        {
            public int CalculateFactorial(int number)
            {
                if (number <= 1)
                    return 1;
                else
                    return number * CalculateFactorial(number - 1);
            }
            public int BinarySearch(int[] sortedArray, int target)
            {
                int left = 0;
                int right = sortedArray.Length - 1;

                while (left <= right)
                {
                    int middle = (left + right) / 2;

                    if (sortedArray[middle] == target)
                        return middle;
                    else if (sortedArray[middle] < target)
                        left = middle + 1;
                    else
                        right = middle - 1;


                }

                return -1;
            }
        }

    }
}
```

Good comment :  
🔑`Recursive Approach` esmplaining **why**