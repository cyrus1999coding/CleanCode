using System.Runtime.CompilerServices;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Worker human = new Worker();
            human.Work();
            human.Eat();

            Robot robot = new Robot();
            robot.Work();

        }

        public interface IWorkable
        {
            void Work();

        }
        public interface IEatable
        {
            void Eat();
        }

        public class Worker : IWorkable, IEatable
        {
            public void Work()
            {
                Console.WriteLine("Working");
            }

            public void Eat()
            {
                Console.WriteLine("Eating");
            }
        }

        public class Robot : IWorkable
        {
            public void Work()
            {
                Console.WriteLine("Working");
            }

        }
    }

}
