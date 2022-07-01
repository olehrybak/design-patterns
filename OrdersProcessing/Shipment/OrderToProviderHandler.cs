using System;
using System.Collections;
using System.Collections.Generic;

namespace OrderProcessing.Shipment
{
    public class OrderToProviderHandler
    {
        private Lazy<LocalShipmentProvider> localProvider;
        private Lazy<GlobalShipmentProvider> globalProvider;

        public OrderToProviderHandler(TaxRatesDB taxDB)
        {
            localProvider = new Lazy<LocalShipmentProvider>(() => new LocalShipmentProvider(taxDB));
            globalProvider = new Lazy<GlobalShipmentProvider>(() => new GlobalShipmentProvider(taxDB));
        }
        
        public void RegisterForShipment(IShippableOrder order){
            if (order.Recipient.Country == "Polska")
            {
                localProvider.Value.RegisterForShipment(order);
            }
            else
            {
                globalProvider.Value.RegisterForShipment(order);
            }
        }

        public IEnumerable<IShipmentProvider> GetUsedProviders()
        {
            yield return localProvider.Value;
            yield return globalProvider.Value;
        }

        public string GetLabelForOrder(IShippableOrder order)
        {
            if (order.Recipient.Country == "Polska")
            {
                return localProvider.Value.GetLabelForOrder(order);
            }
            else
            {
                return globalProvider.Value.GetLabelForOrder(order);
            }
        }
    }
}