using System.Collections.Generic;
using OrderProcessing.Databases;
using OrderProcessing.Orders;

namespace OrderProcessing.Iterators
{
    public class GlobalOrdersIterator : Iterator
    {
        Queue<OrderNode> ordersQueue = new Queue<OrderNode>();
        private GlobalOrdersDB database;
        private OrderNode _current;

        public GlobalOrdersIterator(GlobalOrdersDB db)
        {
            database = db;
            ordersQueue.Enqueue(db.Root);
        }
        
        public override Order Current()
        {
            return _current.Order;
        }

        public override bool MoveNext()
        {
            if (ordersQueue.Count > 0)
            {
                _current = ordersQueue.Dequeue();

                if (_current.Left != null)
                {
                    ordersQueue.Enqueue(_current.Left);
                }

                if (_current.Right != null)
                {
                    ordersQueue.Enqueue(_current.Right);
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Reset()
        {
            ordersQueue.Clear();
            ordersQueue.Enqueue(database.Root);
        }
    }
}