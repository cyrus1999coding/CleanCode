using System.Runtime.CompilerServices;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.ReadKey();
        }

        public class Calculator
        {
            /// <summary>
            /// Adds two numbers together and returns the result.
            /// </summary>
            /// <param name="a">
            /// The first number to add.
            /// </param>
            /// <param name="b">
            /// The second number to add.
            /// </param>
            /// <returns>
            /// The sum of <paramref name="a"/> and <paramref name="b"/>.
            /// </returns>
            public static int Add(int a, int b)
            {
                return a + b;
            }

            /// <summary>
            /// Divides one number by another number.
            /// </summary>
            /// <param name="a">
            /// The number that will be divided.
            /// </param>
            /// <param name="b">
            /// The number to divide by.
            /// </param>
            /// <returns>
            /// The result of dividing <paramref name="a"/> by <paramref name="b"/>.
            /// </returns>
            /// <exception cref="DivideByZeroException">
            /// Thrown when <paramref name="b"/> is zero.
            /// </exception>
            public static double Divide(double a, double b)
            {
                if (b == 0)
                    throw new DivideByZeroException();

                return a / b;
            }
        }
    }
}
