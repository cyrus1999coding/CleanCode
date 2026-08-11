# 022 Interface Segregation Principle (ISP)

Tells us we have to split `Interfaces` if one `Interface` gets too big  
That there are some `Classes` are not using all of the `Interface Methods` .

🔑 imagine we have `Interface` that **Implements** 2 `Methods`, and we have a `Class` that only need  
One `Method` but also has to Implement the secound `Method` because of the 🔑`Interface Contract`  
Then we have an 🔑`Interface Segregation Principle (ISP)` Violation .  
In that case we would have to split up the `Interface` .

```cs
using System.Runtime.CompilerServices;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWorker human = new Worker();
            human.Work();
            human.Eat();

            IWorker robot = new Robot();
            robot.Work();

            try
            {
                robot.Eat();
            }
            catch (NotImplementedException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public interface IWorker
        {
            void Work();
            void Eat();
        }

        public class Worker : IWorker
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

        public class Robot : IWorker 👈
        {
            public void Work()
            {
                Console.WriteLine("Working");
            }
            👇⛔
            public void Eat()
            {
                // Robots do not eat, But are forced to Implement this Method
                throw new NotImplementedException();
            }
            👆
        }
    }

}
```

So we would now create the secound `Interface` to **split up** the *.Work()* and *.Eat()* ↓


```cs
using System.Runtime.CompilerServices;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            🔑🔑👉IWorkable human = new Worker();
            human.Work();
            🔑🔑👉((IEatable)human).Eat();

            IWorkable robot = new Robot();
            robot.Work();

        }
        👇
        public interface IWorkable
        {
            void Work();

        }
        👆
        👇
        public interface IEatable
        {
            void Eat();
        }
        👆
        public class Worker : IWorkable, IEatable 👈🔑
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

        public class Robot : IWorkable 👈
        {
            public void Work()
            {
                Console.WriteLine("Working");
            }

        }
    }

}
```

- GPT :  
  think :  
  `Reference/variable type`: IWorkable  
  `Object/runtime type`: Worker

And instead of using `interfaces` here we can use the `Classes` ↓

```cs
using System.Runtime.CompilerServices;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            👇
            Worker human = new Worker();
            human.Work();
            human.Eat();

            Robot robot = new Robot();
            robot.Work();
            👆
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
```