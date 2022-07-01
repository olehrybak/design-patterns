using System.Collections;
using OrderProcessing.Iterators;
using OrderProcessing.Orders;

namespace OrderProcessing.Databases
{
    public class GlobalOrdersDB
    {
        public OrderNode Root { get; private set; }

        public GlobalOrdersDB(OrderNode root)
        {
            Root = root;
        }

        public Iterator GetIterator()
        {
            return new GlobalOrdersIterator(this);
        }
    }
    public class OrderNode
    {
        public OrderNode Parent { get; }
        public OrderNode Left { get; }
        public OrderNode Right { get; }
        public Order Order { get; }

        public OrderNode(OrderNode left, OrderNode right, Order order)
        {
            this.Left = left;
            this.Right = right;
            this.Order = order;
        }
    }
}