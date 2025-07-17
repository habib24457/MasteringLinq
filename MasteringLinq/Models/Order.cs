namespace MasteringLinq.Models;

public class Order
{
    public int OrderId { get; set; }
    public string OrderName { get; set; }
    public string OrderType { get; set; }

    public int Price { get; set; }
    public string CompanyName { get; set; }
    public int CustomerId { get; set; }
}