using OrderProcessing.Orders;
using OrderProcessing.Payments;

namespace OrderProcessing.ChainOfResponsibility
{
 
    public abstract class ChainHandler
    {
        private ChainHandler nextHandler;

        public ChainHandler SetNext(ChainHandler handler)
        {
            nextHandler = handler;
            return handler;
        }
        
        public virtual object Handle(Order order)
        {
            if (nextHandler != null)
            {
                return nextHandler.Handle(order);
            }
            else
            {
                return null;
            }
        }
    }
}