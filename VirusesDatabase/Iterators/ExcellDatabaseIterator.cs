using System;
using System.Collections.Generic;

namespace Task3
{
    public class ExcellDatabaseIterator : Iterator
    {
        public ExcellDatabase collection;
        int position = -1;

        public string[] Names;
        public string[] DeathRates;
        public string[] InfectionRates;
        public string[] GenomeIds;
        private SimpleGenomeDatabase _genomeDatabase;

        public ExcellDatabaseIterator(ExcellDatabase database, SimpleGenomeDatabase genomeDatabase)
        {
            collection = database;
            _genomeDatabase = genomeDatabase;
            string[] separator = { ";" };
            Names = database.Names.Split(separator, 20, StringSplitOptions.None);
            DeathRates = database.DeathRates.Split(separator, 20, StringSplitOptions.None);
            InfectionRates = database.InfectionRates.Split(separator, 20, StringSplitOptions.None);
            GenomeIds = database.GenomeIds.Split(separator, 20, StringSplitOptions.None);
        }
        

        public override VirusData Current()
        {
            List<GenomeData> genomeList = new List<GenomeData>();
            foreach (var genom in _genomeDatabase.genomeDatas)
            {
                if(genom.Id == Guid.Parse(GenomeIds[position]))
                    genomeList.Add(genom);
            }
            return new VirusData(Names[position], Double.Parse(DeathRates[position]), Double.Parse(InfectionRates[position]), genomeList);
        }

        public override bool MoveNext()
        {
            int updatedPosition = position + 1;

            if (updatedPosition >= 0 && updatedPosition < Names.Length)
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