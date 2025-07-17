using MasteringLinq.Models;

namespace MasteringLinq.DummyData;

public static class DummyData
{
        public static List<Customer> customers = new List<Customer>
        {
            new Customer { CustomerId = 1, Name = "Alice" },
            new Customer { CustomerId = 2, Name = "Bob" },
            new Customer { CustomerId = 3, Name = "Charlie" },
            new Customer { CustomerId = 4, Name = "Diana" },
            new Customer { CustomerId = 5, Name = "Ethan" }
        };
        
        
        public static List<Order> orders = new List<Order>
        {
            new Order { OrderId = 1, OrderName = "Laptop", OrderType = "Electronics",CompanyName = "Saturn",Price = 100,CustomerId = 1},
            new Order { OrderId = 2, OrderName = "Desk Chair", OrderType = "Furniture",CompanyName = "Otobi",Price = 150, CustomerId = 1 },
            new Order { OrderId = 3, OrderName = "Monitor", OrderType = "Electronics",CompanyName = "Saturn",Price = 190,CustomerId = 2 },
            new Order { OrderId = 4, OrderName = "Notebook", OrderType = "Stationery",CompanyName = "Kloner",Price = 80, CustomerId = 1 },
            new Order { OrderId = 5, OrderName = "Smartphone", OrderType = "Electronics",CompanyName = "Saturn",Price = 700, CustomerId = 2 }
        };
    
        public static List<ShipperInfo> shippers { get; } = new List<ShipperInfo>
        {
            new ShipperInfo { ShipperId = 1, CompanyName = "FastTrack Logistics", OrderId = 1 },
            new ShipperInfo { ShipperId = 2, CompanyName = "Global Express", OrderId = 1 },
            new ShipperInfo { ShipperId = 3, CompanyName = "BlueSky Couriers", OrderId = 2 },
            new ShipperInfo { ShipperId = 4, CompanyName = "NorthWind Shippers", OrderId = 2 },
            new ShipperInfo { ShipperId = 5, CompanyName = "QuickRoute Delivery", OrderId = 3 }
        };
}