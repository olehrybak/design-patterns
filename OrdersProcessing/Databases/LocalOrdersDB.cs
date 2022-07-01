using OrderProcessing.Iterators;
using OrderProcessing.Orders;

namespace OrderProcessing.Databases
{
    public class LocalOrdersDB
    {
        public Order[] Orders { get; }

        public LocalOrdersDB(Order[] orders)
        {
            Orders = orders;
        }
        
        public Iterator GetIterator()
        {
            return new LocalOrdersIterator(this);
        }
    }
}