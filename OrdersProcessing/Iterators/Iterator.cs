using System.Collections;
using OrderProcessing.Orders;

namespace OrderProcessing.Iterators
{
    public abstract class Iterator 
    {
        public abstract Order Current();
        
        public abstract bool MoveNext();

        public abstract void Reset();

    }
}