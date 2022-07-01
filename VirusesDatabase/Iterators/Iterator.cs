using System.Collections;

namespace Task3
{
    public abstract class Iterator 
    {
        public abstract VirusData Current();
        
        public abstract bool MoveNext();

        public abstract void Reset();

    }
}