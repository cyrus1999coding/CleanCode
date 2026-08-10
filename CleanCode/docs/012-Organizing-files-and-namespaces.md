# 012 Organizing files and namespaces

```text
// Solotion Explorer

📂 Solution 'CleanCode' (1 of 1 project)

  ↓ 📂 CleanCode (Project)
	→ 📂 Dependencies
	→ 📄 Customer.cs
	→ 📄 CustomerService.cs
	→ 📄 Product.cs
	→ 📄 ProductService.cs
	→ 📄 Program.cs
``` 

- 🔑 Notice that we got 2 `Model`s and 2 `Service`s 

What should we do here is to create 2 `namespace`s .  

```text
// Solotion Explorer

📂 Solution 'CleanCode' (1 of 1 project)

  ↓ 📂 CleanCode (Project)
	→ 📂 Dependencies
	→ 📄 Customer.cs
	→ 📄 CustomerService.cs
	→ 📄 Product.cs
	→ 📄 ProductService.cs
	→ 📄 Program.cs
``` 

`📄Product.cs` :

```cs
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCode
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
```

`📄Customer.cs` :

```cs
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCode
{
    internal class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

```


`📄ProductService.cs` :

```cs
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCode
{
    internal class ProductService
    {
        /// <summary>
        /// TODO: Delete Product
        /// </summary>
        /// <param name="productId"></param>
        public void DeleteProduct(int productId)
        { 
            
        }
    }
}
```

`📄CustomerService.cs` :

```cs
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCode
{
    internal class CustomerService
    {
        /// <summary>
        /// TODO: Get customer by id
        /// </summary>
        /// <param name="customerId"></param>
        public void GetCustomerById(int customerId)
        { 
            
        }
    }
}
```


`Customer.cs` :

```cs
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCode👉.Models👈
{
    internal class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
```

`Product.cs` :

```cs
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCode👉.Models👈
{
    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
```

`CustomerService.cs` :

```cs
using System;
using System.Collections👉.Generic👈;
using System.Text;

namespace CleanCode.Services
{
    internal class CustomerService
    {
        /// <summary>
        /// TODO: Get customer by id
        /// </summary>
        /// <param name="customerId"></param>
        public void GetCustomerById(int customerId)
        { 
            
        }
    }
}
```

`ProductService.cs`

```cs
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCode👉.Services👈
{
    internal class ProductService
    {
        /// <summary>
        /// TODO: Delete Product
        /// </summary>
        /// <param name="productId"></param>
        public void DeleteProduct(int productId)
        { 
            
        }
    }
}
```

🔑 Now we have 2 namespaces `Models` and `Services` and each of them holds the `Data Structure` So the `Classes` that they should hold.

Now we need to create 2 new Folders now ↓

```text
// Solotion Explorer

📂 Solution 'CleanCode' (1 of 1 project)

  ↓ 📂 CleanCode (Project)
	→ 📂 Dependencies
    ↓ 📂 Services 👈
        → 📄 CustomerService.cs
        → 📄 ProductService.cs
    ↓ 📂 Models 👈
	    → 📄 Customer.cs
        → 📄 Product.cs
	→ 📄 Program.cs
```

Now if we wanna use all of this inside of our `prgram.cs` ↓

```cs
using CleanCode.Models; 👈
using CleanCode.Services; 👈
using System.Runtime.CompilerServices;

namespace CleanCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomerService customerService = new CustomerService();
            Customer customer = new Customer();

            Console.ReadKey();
        }


    }
}
```