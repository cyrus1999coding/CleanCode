using System.Runtime.CompilerServices;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bird sparrow = new Sparrow();
            sparrow.MakeSound();
            ((IFlyable)sparrow).Fly();

            Bird penguin = new Penguin();
            penguin.MakeSound();

            Console.ReadKey();
        }
    }

    public class Bird
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("Chirp");
        }
    }

    public class Sparrow : Bird, IFlyable
    {
        public void Fly()
        {
            Console.WriteLine("Flying");
        }
    }

    public class Penguin : Bird
    {
        public override void MakeSound()
        {
            base.MakeSound();
        }
    }

    public interface IFlyable
    {
        void Fly();
    }

}
