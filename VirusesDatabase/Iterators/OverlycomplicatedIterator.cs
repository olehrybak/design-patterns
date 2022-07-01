using System.Collections.Generic;

namespace Task3
{
    public class OverlycomplicatedIterator : Iterator
    {
        public List<INode> list = new List<INode>();
        public int position = -1;
        public OvercomplicatedDatabase collection;
        public SimpleGenomeDatabase _genomeDatabase;

        public OverlycomplicatedIterator(OvercomplicatedDatabase database, SimpleGenomeDatabase genomeDatabase)
        {
            collection = database;
            _genomeDatabase = genomeDatabase;
            list.Add(database.Root);
            CreateList(database.Root);
        }
        
        public void CreateList(INode node)
        {
            foreach (var child in node.Children)
            {
                CreateList(child);
                list.Add(child);
            }
        }

        public override VirusData Current()
        {
            INode element = list[position];
            List<GenomeData> genomeList = new List<GenomeData>();
            foreach (var genom in _genomeDatabase.genomeDatas)
            {
                foreach (var tag in genom.Tags)
                {
                    if(tag == element.GenomeTag)
                        genomeList.Add(genom);
                }
            }
            return new VirusData(element.VirusName, element.DeathRate, element.InfectionRate, genomeList);
        }

        public override bool MoveNext()
        {
            int updatedPosition = position + 1;

            if (updatedPosition >= 0 && updatedPosition < list.Count)
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