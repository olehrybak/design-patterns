using System;
using OrderProcessing.Orders;

namespace OrderProcessing.ChainOfResponsibility
{
    public class HandlerControl
    {
        public void HandlerControlClient(Order order)
        {
                Console.WriteLine($"Processing Order {order.OrderId} with total amount {order.AmountToBePaid}");
                order.Status = OrderStatus.PaymentProcessing;
                var handler1 = new PaypalHandler();
                var handler2 = new InvoiceHandler();
                var handler3 = new CreditCardHandler();
                handler1.SetNext(handler2).SetNext(handler3);
                handler1.Handle(order);
                if (order.DueAmount == 0)
                {
                    Console.WriteLine($"Order {order.OrderId} is ready for shipment");
                    order.Status = OrderStatus.ReadyForShipment;
                }
                else
                {
                    Console.WriteLine($"Order {order.OrderId} has insufficient paid amount {order.PaidAmount}");
                    order.Status = OrderStatus.WaitingForPayment;
                }
                Console.WriteLine();
        }
    }
}