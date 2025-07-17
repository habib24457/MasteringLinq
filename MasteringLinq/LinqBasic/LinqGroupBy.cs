using MasteringLinq.Models;

namespace MasteringLinq.LinqBasic;

public class LinqGroupBy
{
    /*GroupBy: Is used when
     *Find out the top customers by number of orders?
     * Find out total amount spent by each customer?
     * Find all orders that have been shipped (joined with shipper info)
     * Count number of shippers per order
     * Find customers who haven’t placed any orders
     * Find total orders and total spending by company name (Saturn, Otobi, etc.)
     */
    
    public List<Customer> customers = DummyData.DummyData.customers;
    public List<Order> orders = DummyData.DummyData.orders;
    public List<ShipperInfo> shippers = DummyData.DummyData.shippers;
    
    //1.Find out the top customers by number of orders
    public void FindTopCustomersByOrderNumbers()
    {

    }
    
}