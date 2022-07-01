using System.Collections.Generic;
using System.Reflection.Emit;

namespace Task3
{
    public class SimpleDatabaseIterator : Iterator
    {
        public SimpleDatabase collection;
        int position = -1;
        private SimpleGenomeDatabase _genomeDatabase;

        public SimpleDatabaseIterator(SimpleDatabase database, SimpleGenomeDatabase genomeDatabase)
        {
            collection = database;
            _genomeDatabase = genomeDatabase;
        }
        

        public override VirusData Current()
        {
            SimpleDatabaseRow element = collection.Rows[position];
            List<GenomeData> genomeList = new List<GenomeData>();
            foreach (var genom in _genomeDatabase.genomeDatas)
            {
                if(genom.Id == element.GenomeId)
                    genomeList.Add(genom);
            }
            return new VirusData(element.VirusName, element.DeathRate, element.InfectionRate, genomeList);
        }

        public override bool MoveNext()
        {
            int updatedPosition = position + 1;

            if (updatedPosition >= 0 && updatedPosition < collection.Rows.Count)
            {
                position = updatedPosition;
                return true;
            } 
            return false;
            
        }

        public override void Reset()
        {
            position = -1;
        }
    }
}