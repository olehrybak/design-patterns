using OrderProcessing.Orders;

namespace OrderProcessing.Iterators
{
    public class ReadyFilterIterator : Iterator
    {
        private Iterator iter;

        public ReadyFilterIterator(Iterator iterator)
        {
            iter = iterator;
        }
        public override Order Current()
        {
            Order current = iter.Current();
            if (current.Status == OrderStatus.ReadyForShipment)
                return current;
            return null;
        }

        public override bool MoveNext()
        {
            return iter.MoveNext();
        }

        public override void Reset()
        {
            iter.Reset();
        }
    }
}