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