using System;

namespace Task3
{
    public class FilterIterator : Iterator
    {
        private Iterator iter;
        private Func<VirusData, bool> filterFunc;

        public FilterIterator(Iterator iterator, Func<VirusData, bool> func)
        {
            iter = iterator;
            filterFunc = func;
        }
       

        public override VirusData Current()
        {
            VirusData data = iter.Current();
            if (filterFunc(data))
                return data;
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