using MasteringLinq.DummyData;
using MasteringLinq.Models;

namespace MasteringLinq.LinqBasic;


public class LinqJoins
{
    public List<Customer> customers = DummyData.DummyData.customers;
    public List<Order> orders = DummyData.DummyData.orders;
    public List<ShipperInfo> shippers = DummyData.DummyData.shippers;
    public void InnerJoinLogic()
    {
        var customersOrder = from c in customers
            join o in orders
                on c.CustomerId equals o.CustomerId
            select new
            {
                c.Name,
                o.OrderName,
                o.OrderType
            };

        var customersOrderByMethodSyntax = customers.Join(
            orders,
            c=>c.CustomerId,
            o => o.CustomerId,
            (c,o) => new
            {
                c.Name,
                o.OrderName,
                o.OrderType
            }
            );
        
        foreach (var co in customersOrder)
        {
            Console.WriteLine($"{co.Name} ordered {co.OrderName} ({co.OrderType})");
        }
        Console.WriteLine(new string('.',60));
        Console.WriteLine("Join logic written by method syntax");
        foreach (var co in customersOrderByMethodSyntax)
        {
            Console.WriteLine($"{co.Name} ordered {co.OrderName} ({co.OrderType})");
        }
        
    }
    public void InnerJoinMoreThanTwoTable()
    {
        Console.WriteLine(new string('-', 20)+"Joining three tables Order, Customer and Shipping Company"+new string('-', 20));
        Console.WriteLine(new string('-', 60));
        Console.WriteLine("Customer".PadRight(15) + "Order".PadRight(20) + "Shipping Company".PadRight(25));
        Console.WriteLine(new string('-', 60));
        var orderAndShipperInfo = from c in customers
            join o in orders
                on c.CustomerId equals o.CustomerId
            join s in shippers
                on o.OrderId equals s.OrderId

            select new
            {
                c.Name,
                o.OrderName,
                s.CompanyName,
                ShippingCompany = o.CompanyName
            };
        
        var orderAndShipperInfoMethodSyntax = customers
            .Join(orders,
                c => c.CustomerId,
                o => o.CustomerId,
                (c, o) => new { c, o })
            .Join(shippers,
                co => co.o.OrderId,
                s => s.OrderId,
                (co, s) => new
                {
                    co.c.Name,
                    co.o.OrderName,
                    co.o.CompanyName,
                    ShippingCompany = s.CompanyName
                });
        
        // Data Rows
        foreach (var item in orderAndShipperInfo)
        {
            Console.WriteLine(
                item.Name.PadRight(15) +
                item.OrderName.PadRight(20) +
                item.ShippingCompany.PadRight(25)
            );
        }
    } 
    public void JoinThreeTablesAndFilter()
    {
        Console.WriteLine(new string('-', 20)+"Joining three tables Order, Customer and Shipping Company"+new string('-', 20));
        Console.WriteLine(new string('-', 130));
        Console.WriteLine("Customer".PadRight(15) + 
                          "Order".PadRight(20) +
                          "Ordered From".PadRight(35) +
                          "Order Type".PadRight(20) +
                          "Price".PadRight(20) +
                          "Shipping Company".PadRight(25));
        Console.WriteLine(new string('-', 130));
        
        var orderAndShipperInfo = from c in customers
            join o in orders
                on c.CustomerId equals o.CustomerId
            join s in shippers
                on o.OrderId equals s.OrderId
            where o.Price > 100
            select new
            {
                c.Name,
                o.OrderName,
                s.CompanyName,
                o.Price,
                ShippingCompany = o.CompanyName
            };  
        
        // Data Rows
        foreach (var item in orderAndShipperInfo)
        {
            Console.WriteLine(
                item.Name.PadRight(15) +
                item.OrderName.PadRight(20) +
                item.CompanyName.PadRight(35) +
                item.OrderName.PadRight(20) +
                item.Price.ToString().PadRight(15)+
                item.ShippingCompany.PadRight(25)
            );
        }
    }

    public void LeftJoinLogic()
    {
        /*Let the Order table to be the left table or 1st table
         * Let the Customer table to be the right table or 2nd table
         * Left Join will take: Everything from Left table.
         * Only the matched values from the Right table
         */
        var matchedOrders = from c in customers
            join o in orders
                on c.CustomerId equals o.CustomerId
                into gp
            from g in gp.DefaultIfEmpty()
            select new
            {
                c.CustomerId,
                g.OrderId,
                g.CompanyName
            };
    }

    public void CrossJoinLogic()
    {
        /*Cross join: 
         * 
         */

        var customerIntoOrder = from c in customers
            from o in orders
            select new
            {
                c.CustomerId,
                o.OrderId
            };
    }

    public void OptimizeLinq()
    {
        /*Linq has two types of syntax
         * Query based: from c in customer join o in order...
         * Method based syntax: Customers.Select...
         */

        //Query based
        var customer = from c in customers 
            where c.CustomerId > 1
                select new
            {
                c.Name
            };

        //Method based
        var customerMethod = customers
            .Where(c => c.CustomerId > 1)
            .Select(c => c.Name);

    }
    
    
}