using System;
using System.Collections.Generic;
using System.Linq;

public class Customer
{
    public string Name { get; set; }
    public List<Order> Orders { get; set; }
}

public class Order
{
    public string Product { get; set; }
    public decimal Amount { get; set; }
}

//Task:
//Using LINQ, find the top 3 customers by their total order amount.
//Return only their names and total spend.
public class TopCustomersBySpend
{
    public List<Customer> Customers { get; set; }
    public TopCustomersBySpend()
    {
        Customers = new List<Customer>
        {
            new Customer { Name = "Alice", Orders = new List<Order> {
                new Order { Product = "Book", Amount = 30 },
                new Order { Product = "Pen", Amount = 5 }
            }},
            new Customer { Name = "Bob", Orders = new List<Order> {
                new Order { Product = "Laptop", Amount = 1200 },
                new Order { Product = "Mouse", Amount = 25 }
            }},
            new Customer { Name = "Charlie", Orders = new List<Order> {
                new Order { Product = "Phone", Amount = 800 }
            }},
            new Customer { Name = "Diana", Orders = new List<Order> {
                new Order { Product = "Tablet", Amount = 400 }
            }},
        };
    }

    public void GetTopCustomersBySpend()
    {
        var top3Customers = this.Customers
        .Select(c => new { Name = c.Name, TotalAmountSpent = c.Orders.Sum(o => o.Amount) })
        .OrderByDescending(r => r.TotalAmountSpent).Take(3);

        foreach (var cust in top3Customers) {
            Console.WriteLine($"Name: {cust.Name}, Amount Spent: {cust.TotalAmountSpent}");
        }
    }
}