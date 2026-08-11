# 021 Liskov Substitution Principle (LSP)

🔑 `Liskov Substitution` :  

We can replace our 🔑`Derived Classes` with 🔑`Base Clases` without causing Errors .

```cs
using System.Runtime.CompilerServices;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bird sparrow = new Bird();
            sparrow.Fly();

            Bird penguin = new Penguin();
            penguin.Fly(); // This will throw and exeption . ❌

            Console.ReadKey();
        }
    }

    public class Bird
    {
        public virtual void Fly()
        {
            Console.WriteLine("Flying");
        }
    }

    public class Penguin : Bird
    {

        public override void Fly()
        {
            throw new NotImplementedException("Penguins cannot fly"); ❌
        }
    }

}
```
- If we're Run the app right now we'll get an Exeption ↓  
- ❌ : [System.NotImplementedException unhandled]	

The 🔑 `Liskov Substitution` says that we should be able to replace our `Derived Classes` with our `Base Classes`  
So we should able to say :  
✅ : that the *penguin* is a Bird → `Bird penguin = new Penguin();`  
⛔ : We shouldn't be able to call the *.Fly()* on a *penguin* → `penguin.Fly();`

So how could we solve this problem how we could just say that a *penguin* is a *Bird*, But the *penguin* has no option to *.Fly()* ❔  
⛔🔑 We don't wanna provide the *.Fly()* `Method` on the `Class` *Penguin*, Just for another developer to call the  
*.Fly()* `Method` on a *Penguin* to cause an Exeption .  
💡 :

```cs
using System.Runtime.CompilerServices;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bird sparrow = new Sparrow();
            sparrow.MakeSound();
            🔑🔑👉((IFlyable)sparrow).Fly();

            Bird penguin = new Penguin();
            penguin.Fly(); // This will throw and exeption .

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

    public class Sparrow : Bird, IFlyable 👈🔑🔑
    {
        public void Fly()
        {
            Console.WriteLine("Flying");
        }
    }

    public class Penguin : Bird
    {

        public override void Fly()
        {
            throw new NotImplementedException("Penguins cannot fly");
        }
    }
    👇
    public interface IFlyable
    {
        void Fly();
    }
    👆

}

```
- `((IFlyable)sparrow).Fly();` :  
  🔑🔑 We 🔑`Cast` the *sparrow* here to **Implement** the *IFlyable* on the *Bird* 🔑`Base Class`

Next we have our *penguin* ↓

```cs
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
            penguin.Fly(); // This will throw and exeption . 👈⛔

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
    👇
    public class Penguin : Bird
    {
        public override void MakeSound()
        {
            base.MakeSound();
        }
    }
    👆
    public interface IFlyable
    {
        void Fly();
    }

}
```
- `penguin.Fly();` :  
  Now we're not even able to call this `Method` what we can do instead is  
  ```cs
  penguin.MakeSound(); ✅
  ```

```cs
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
```

🔑 So basically we have 2 *Bird*s the 🔑`Base Class` ↓  

```cs
Bird sparrow = new Sparrow();
Bird penguin = new Penguin();
```

And on one of them we can call the *.Fly()* and in the other one we can't And that's  
🔑🔑 Because we're using an `Interface`, Then we 🔑`Casting` our 🔑`Base Class` *Bird* → *Bird sparrow*  
to the *IFlyable* `Interface` and then call the *.Fly()* `Method`  
And that wat we're able to achieve that our 🔑`Derived Clasess` does not break anything when we use it like a  
🔑`Base Class` .

📝 :  
When using `Interfaces` this is possible to face this `Liskov Substitution` which is advanced .  
Where we have 2 `Derived Classes` and 1 of them has a functionality that shouldn't be there but ew wneed that  
Functionality on the other `Derived Class` .