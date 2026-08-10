# 018 SOLID presentation

🔑`SOLID` :

1. Single Responsibility

A `Class` should have only **One** job or responsibility .

2. Open/Closed  

Softwate enitties should be open for extension but closed for modification .  
✅ If we wanna add more functionality we would `Inheritance`, `Interfaces` and ..  
⛔ Closed for Modification of the existing code .  

3. Liskov Substitution  

`Sub-Classes` should be replaceable with theur Base Classes without  
Breaking the program .

4. Interface Segregation  

Clients should not be forced to depend on `Interfaces` they do not use .  

🔑 If we have bloated `Interfaces` with tons of functionality but our `Classes`  
Are not using all of those `Methods` that we have inside our `Interfaces`  
Then we should break that bloated `Interfaces` into smaller `Interfaces` .

5. Dependency Inversion

High-Level Modules should depend on Abstractions, Not on Lo-Level Modules