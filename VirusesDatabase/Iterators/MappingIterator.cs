using System;

namespace Task3
{
    public class MappingIterator : Iterator
    {
        private Iterator iter;
        private Func<VirusData, VirusData> mappingFunc;

        public MappingIterator(Iterator iterator, Func<VirusData, VirusData> func)
        {
            iter = iterator;
            mappingFunc = func;
        }
        public override VirusData Current()
        {
            return mappingFunc(iter.Current());
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