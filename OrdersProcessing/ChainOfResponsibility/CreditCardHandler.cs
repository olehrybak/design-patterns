using System;
using OrderProcessing.Orders;
using OrderProcessing.Payments;

namespace OrderProcessing.ChainOfResponsibility
{
    public class CreditCardHandler : ChainHandler
    {
        public override object Handle(Order order)
        {
            foreach (Payment payment in order.SelectedPayments)
            {
                if (payment.PaymentType == PaymentMethod.CreditCard)
                {
                        if (payment.Amount > order.DueAmount)
                        {
                            payment.Amount = order.DueAmount;
                        }
                        Console.WriteLine($"Order {order.OrderId} paid {payment.Amount} via CreditCard");
                        order.FinalizedPayments.Add(payment);
                        
                        if (order.DueAmount == 0)
                            return null;
                }
            }
            return base.Handle(order);
        }
    }
}