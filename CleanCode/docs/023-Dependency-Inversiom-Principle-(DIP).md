# 023 Dependency Inversion Principle (DIP)

We use the 🔑`DIP` to reduce the 🔑`Coupling` between `High-Level` and `Low-Level` 🔑`Modules` .

```cs
using System.Runtime.CompilerServices;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Notification notification = new Notification();
            notification.Send("Hello, This is a test notification.");

        }
    }

    public class EmailService
    {
        public void SendEmail(string to, string subject, string body)
        {
            Console.WriteLine($"Sending email to {to}, with subject {subject}");
        }
    }

    public class Notification
    {
        private readonly EmailService _emailService; 👈⛔

        public Notification()
        { 
            _emailService = new EmailService(); 👈
        }

        public void Send(string message)
        {
           👉 _emailService.SendEmail("user@example.com", "Notification", message);
        }
    }

}
```

- `private readonly EmailService _emailService;` :  
  Here we **Require** an `Instance` of the *EmailService* `Class` and that's **Hard Coded** .  
  We're not using an **Abstract Version** or an `Interface`,  
  We rely exactly on that *EmailService* `Class`

- `_emailService = new EmailService();` :  
  Inside the `Constructor` of the *Notification* `Class` we directly create that `Instance`  
  Of that *EmailService* .  
  🔑 So our 🔑`High-Level Module` (*Notification*), creates a 🔑`Low-Level Module` `Instance` (*EmailService*) .  
  ⛔ This is the violation and shouldn't happen, A 🔑`High-Level Module` shouldn't create an `Instance` of the  🔑`Low-Level Module` and it's time to reduce the 🔑`Coupling` here .
  

🔑 Usually ant **Service** that we create in our application will be a 🔑`Low-Level Module`  
Because it offers 🔑`Generic Functionality` or 🔑`Core Functionality`  like *Sending Emails*  

And we `Class` *Notification* that is using that `Class` *EmailService*   
🔑 **Relies** on the *EmailService* therefore it's a 🔑`High-Level Module`

We use the 🔑`Dependency Inversion Principle (DIP)` to Reduce the 🔑`Coupling`  
Between both of them .

🚀 Our Goal is we can submit an *EmailService* to our *Notification* without using the *Class* Directly in there .  
We wanna use the 🔑`Abstract Version` such as an 🔑`Interface` for example .

```cs
using System.Runtime.CompilerServices;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Notification notification = new Notification(); //⛔ (We have to submit an emailservice now)
            notification.Send("Hello, This is a test notification.");

        }
    }
    👇
    public interface IEmailService
    {
        public void SendEmail(string to, string subject, string body);
    }
    👆
    public class EmailService : IEmailService 👈
    {
        public void SendEmail(string to, string subject, string body)
        {
            Console.WriteLine($"Sending email to {to}, with subject {subject}");
        }
    }

    public class Notification
    {
        private readonly IEmailService👈 _emailService;

        public Notification(👉IEmailService emailService👈)
        {
            _emailService = emailService; 👈
        }

        public void Send(string message)
        {
            👉✅_emailService.SendEmail("user@example.com", "Notification", message);
        }
    }

}
```
- 🚀✅ : Now we're not **Creating** an `Instance` of a 🔑`Low-Level Module` inside of a 🔑`High-Level Module` .
- `_emailService.SendEmail("user@example.com", "Notification", message);` :  
  We can still use `_emailService` with an `Interface`

Now :

```cs
using System.Runtime.CompilerServices;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEmailService emailService = new EmailService(); 👈
            Notification notification = new Notification(emailService); 👈
            notification.Send("Hello, This is a test notification.");

        }
    }

    public interface IEmailService
    {
        public void SendEmail(string to, string subject, string body);
    }

    public class EmailService : IEmailService
    {
        public void SendEmail(string to, string subject, string body)
        {
            Console.WriteLine($"Sending email to {to}, with subject {subject}");
        }
    }

    public class Notification
    {
        private readonly IEmailService _emailService;

        public Notification(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public void Send(string message)
        {
            _emailService.SendEmail("user@example.com", "Notification", message);
        }
    }

}
```
- ✅🚀🛠: Now we've entirely 🔑`De-Coupled` it 

🔑 In this way we'll be also able to Provide some more 🔑`Mock Information`, If we `Hard Coded` to our `Class` *EmailService*,  
We would always have to **Create** exactly an `Instance` of that `Class` *EmailService* .  
🔑But in Real-World when we create 🔑`Unit Tests` for example or just a `Class` for 🔑`Mock` we could now **Create**  ↓  

```cs
using System.Runtime.CompilerServices;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IEmailService emailService = new MockEmailService(); 👈
            Notification notification = new Notification(emailService);
            notification.Send("Hello, This is a test notification.");

        }
    }

    public interface IEmailService
    {
        public void SendEmail(string to, string subject, string body);
    }

    public class EmailService : IEmailService
    {
        public void SendEmail(string to, string subject, string body)
        {
            Console.WriteLine($"Sending email to {to}, with subject {subject}");
        }
    }

    public class Notification
    {
        private readonly IEmailService _emailService;

        public Notification(IEmailService emailService)
        {
            _emailService = emailService;
        }

        public void Send(string message)
        {
            _emailService.SendEmail("user@example.com", "Notification", message);
        }
    }
    👇
    public class MockEmailService : IEmailService
    {
        public void SendEmail(string to, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
    👆

}
```
- And the code will run fine there is no **Implementation** Issue becasue we have made use of the  
  `Dependency Inversion Principle (DIP)` so that 🔑`High-Level Module` functionality is not `Coupled`  
  to 🔑`Low-Level Module` functionality .