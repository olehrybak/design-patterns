using System;
using OrderProcessing.Orders;
using OrderProcessing.Payments;

namespace OrderProcessing.ChainOfResponsibility

{
    public class PaypalHandler : ChainHandler
    {
        private Random rand = new Random(1234);
        public override object Handle(Order order)
        {
            foreach (Payment payment in order.SelectedPayments)
            {
                if (payment.PaymentType == PaymentMethod.PayPal)
                {
                    if (rand.Next(1, 101) > 30)
                    {
                        if (payment.Amount > order.DueAmount)
                        {
                            payment.Amount = order.DueAmount;
                        }
                        Console.WriteLine($"Order {order.OrderId} paid {payment.Amount} via PayPal");
                        order.FinalizedPayments.Add(payment);
                    }
                    else
                    {
                        Console.WriteLine($"Order {order.OrderId} payment PayPal has failed");
                    }

                    if (order.DueAmount == 0)
                        return null;
                }
            }
            return base.Handle(order);
        }
    }
}