using System.Collections.Generic;
using Microsoft.VisualBasic;
using OrderProcessing.Databases;
using OrderProcessing.Orders;

namespace OrderProcessing.Iterators
{
    public class LocalOrdersIterator : Iterator
    {
        private LocalOrdersDB _database;
        public int Position = -1;

        public LocalOrdersIterator(LocalOrdersDB db)
        {
            _database = db;
        }

        public override Order Current()
        {
            return _database.Orders[Position];
        }

        public override bool MoveNext()
        {
            int updatedPosition = Position + 1;

            if (updatedPosition >= 0 && updatedPosition < _database.Orders.Length)
            {
                Position = updatedPosition;
                return true;
            } 
            return false;
            
        }

        public override void Reset()
        {
            Position = -1;
        }
        
    }
}