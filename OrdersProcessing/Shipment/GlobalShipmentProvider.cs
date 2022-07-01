using System;
using System.Collections.Generic;
using OrderProcessing.Databases;
using OrderProcessing.Orders;

namespace OrderProcessing.Shipment
{
    public class GlobalShipmentProvider : IShipmentProvider
    {
        public string Name { get; }
        private Dictionary<string, Parcel> Parcels;
        private Dictionary<string, List<IShippableOrder>> Orders;
        private TaxRatesDB TaxRatesDb;

        public GlobalShipmentProvider(TaxRatesDB taxRatesDb)
        {
            Orders = new Dictionary<string, List<IShippableOrder>>();
            Parcels = new Dictionary<string, Parcel>();
            TaxRatesDb = taxRatesDb;
        }

        public void RegisterForShipment(IShippableOrder order)
        {
            LinearTaxCalculator TaxCalculator;
            if (TaxRatesDb.TaxRates.ContainsKey(order.Recipient.Country))
            {
                TaxCalculator = new LinearTaxCalculator(TaxRatesDb.TaxRates[order.Recipient.Country]);
            }
            else
            {
                TaxCalculator = new LinearTaxCalculator(0);
            }
           
            var summaryFormatter = new SummaryFormatter(TaxCalculator);
            
            if(Orders.ContainsKey(order.Recipient.Country)){
                Orders[order.Recipient.Country].Add(order);
            }
            else
            {
                Orders.Add(order.Recipient.Country, new List<IShippableOrder>());
                Orders[order.Recipient.Country].Add(order);
            }
            
            Parcel parcel;
            if (Parcels.ContainsKey(order.Recipient.Country))
            {
                parcel = Parcels[order.Recipient.Country];
            }
            else
            {
                parcel = new Parcel();
            } 
            
            parcel.BundleHeader = summaryFormatter.PrintHeader(order.Recipient.Country);
            parcel.BundlePrice += order.PaidAmount;
            parcel.BundleTax += TaxCalculator.CalculateTax(order.PaidAmount);
            parcel.BundlePriceWithTax += TaxCalculator.CalculateTax(order.PaidAmount) + order.PaidAmount;
            parcel.Summary = summaryFormatter.PrintOrdersSummary(Orders[order.Recipient.Country]);

            if (Parcels.ContainsKey(order.Recipient.Country))
            {
                Parcels[order.Recipient.Country] = parcel;
                return;
            }
            Parcels.Add(order.Recipient.Country, parcel);
        }

        public string GetLabelForOrder(IShippableOrder order)
        {
            return (new LabelFormatter()).GenerateLabelForOrder("Global", order.Recipient);
        }

        public IEnumerable<IParcel> GetParcels()
        {
            foreach (var parcel in Parcels)
            {
                yield return parcel.Value;
            }
        }
    }
}