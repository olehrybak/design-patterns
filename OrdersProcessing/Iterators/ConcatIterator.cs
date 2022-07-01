using OrderProcessing.Orders;

namespace OrderProcessing.Iterators
{
    public class ConcatIterator : Iterator
    {
        private Iterator iter1;
        private Iterator iter2;
        private bool isOnIter2 = false;
        
        public ConcatIterator(Iterator iterator1, Iterator iterator2)
        {
            iter1 = iterator1;
            iter2 = iterator2;
        }
        
        public override Order Current()
        {
            if (!isOnIter2)
            {
                return iter1.Current();
            }
            else
            {
                return iter2.Current();
            }
        }

        public override bool MoveNext()
        {
            if (iter1.MoveNext())
            {
                return true;
            }
            else if (iter2.MoveNext())
            {
                isOnIter2 = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override void Reset()
        {
            isOnIter2 = false;
            iter1.Reset();
            iter2.Reset();
        }
    } 
}