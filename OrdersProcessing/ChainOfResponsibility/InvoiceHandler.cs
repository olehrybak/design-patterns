using System;
using OrderProcessing.Orders;
using OrderProcessing.Payments;

namespace OrderProcessing.ChainOfResponsibility
{
    public class InvoiceHandler : ChainHandler
    {
        public static int Counter;
        public override object Handle(Order order)
        {
            foreach (Payment payment in order.SelectedPayments)
            {
                if (payment.PaymentType == PaymentMethod.Invoice)
                {
                    Counter++;
                    if (Counter != 3)
                    {
                        if (payment.Amount > order.DueAmount)
                        {
                            payment.Amount = order.DueAmount;
                        }
                        Console.WriteLine($"Order {order.OrderId} paid {payment.Amount} via Invoice");
                        order.FinalizedPayments.Add(payment);
                    }
                    else
                    {
                        Counter = 0;
                        Console.WriteLine($"Order {order.OrderId} payment Invoice has failed");
                    }
                    
                    if (order.DueAmount == 0)
                        return null;
                }
                
            }
            return base.Handle(order);
        }
    }
}