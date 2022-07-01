namespace Task3
{
    public class CreateIterator
    {
        private Iterator iter;
        
        public CreateIterator(SimpleDatabase db, SimpleGenomeDatabase genomeDb)
        {
            iter = new SimpleDatabaseIterator(db, genomeDb);
        }
        
        public CreateIterator(ExcellDatabase db, SimpleGenomeDatabase genomeDb)
        {
            iter = new ExcellDatabaseIterator(db, genomeDb);
        }
        
        public CreateIterator(OvercomplicatedDatabase db, SimpleGenomeDatabase genomeDb)
        {
            iter = new OverlycomplicatedIterator(db, genomeDb);
        }

        public Iterator GetIterator()
        {
            return iter;
        }
    }
}