using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNPAssignment4
{
    class Program
    {
        static void Main(string[] args)
        {
            Product milk = new Product { Name = "Milk", Price = 5 };
            Product butter = new Product { Name = "Butter", Price = 10 };
            Product bread = new Product { Name = "Bread", Price = 15 };
            Product cacao = new Product { Name = "Cacao", Price = 20 };

            Customer kim = new Customer {
                    Name = "Kim Foged",
                    City = "Beder",
                    Orders = new Order[] {
                        new Order {
                                Quantity = 1,
                                Product = milk },
                        new Order {
                                Quantity = 2,
                                Product = butter },
                        new Order {
                                Quantity = 3,
                                Product = bread }
                } };

            Customer ibHavn = new Customer {
                Name = "Ib Havn",
                City = "Horsens",
                Orders = new Order[] {
                        new Order {
                                Quantity = 1,
                                Product = milk },
                        new Order {
                                Quantity = 1,
                                Product = butter },
                        new Order {
                                Quantity = 1,
                                Product = bread },
                        new Order {
                                Quantity = 1,
                                Product = cacao }
                } };

            Customer rasmus = new Customer {
                Name = "Rasmus Bjerner",
                City = "Horsens",
                Orders = new Order[] {
                    new Order {
                        Quantity = 1,
                        Product = new Product { Name = "Juice", Price = 25 }
                    }
                } };
            List<Customer> customers = new List<Customer> { kim, ibHavn, rasmus };

            //b) select all customers, print name and city for each
            Console.WriteLine("Printing name and city for all customers: ");
            customers.Select(o => o).ToList().ForEach(x => Console.WriteLine("Name = {0}, City = {1}", x.Name, x.City));
            Console.WriteLine();

            //c) Name and city of customers from Horsens
            Console.WriteLine("Printing name and city for customers from Horsens: ");
            customers.Where(c => c.City == "Horsens").ToList().ForEach(x => Console.WriteLine("Name = {0}, City = {1}", x.Name, x.City));
            Console.WriteLine();

            //d)Select count of orders for customer Ib Havn
            int ordersForIb = customers.Where(c => c.Name == "Ib Havn").Select(c => c.Orders).Count();
            Console.WriteLine("No of Orders for Ib Havn = {0}", ordersForIb);
            Console.WriteLine();

            //e)Select all customers buying milk
            Console.WriteLine("Customers buying milk: ");
            customers.Where(c => c.Orders.Any(x => x.Product.Name == "Milk")).ToList().ForEach(x => Console.WriteLine("Name = {0}, City = {1}", x.Name, x.City));
            Console.WriteLine();

            //f)total sum, price of products in orders for each customer
            Console.WriteLine("Total sum of all orders for each customer: ");
            var ordersForCustomers = from cust in customers
                                     group cust by cust.Name into custGroup
                                     select new
                                     {
                                         Name = custGroup.Key,
                                         TotalOrders = custGroup.Sum(x => x.Orders.Sum(y => y.Quantity * y.Product.Price))
                                     };
            foreach (var order in ordersForCustomers)
            {
                Console.WriteLine(order);
            }
            Console.WriteLine();

            Console.WriteLine("2nd solution for f)");
            customers.Select(x => new { x.Name, Sum = x.Orders.Sum(y => y.Quantity * y.Product.Price) }).ToList().ForEach(Console.WriteLine);
            Console.WriteLine();

            //g)total sum(all customers added)
            Console.WriteLine("Total price of all products in all orders from all customers..all: ");
            Console.WriteLine(customers.SelectMany(c => c.Orders).Sum(o => o.Product.Price * o.Quantity));
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
