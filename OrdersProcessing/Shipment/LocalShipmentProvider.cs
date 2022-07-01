using System;
using System.Collections;
using System.Collections.Generic;
using OrderProcessing.Orders;

namespace OrderProcessing.Shipment
{
    public class LocalShipmentProvider : IShipmentProvider
    {
        private Parcel Parcel;
        public string Name { get; }
        private List<IShippableOrder> Orders;
        private TaxRatesDB TaxRatesDb;

        public LocalShipmentProvider(TaxRatesDB taxRatesDb)
        {
            Parcel = new Parcel();
            Orders = new List<IShippableOrder>();
            TaxRatesDb = taxRatesDb;
        }

        public void RegisterForShipment(IShippableOrder order)
        {
            LinearTaxCalculator TaxCalculator = new LinearTaxCalculator(TaxRatesDb.TaxRates[order.Recipient.Country]);
            var summaryFormatter = new SummaryFormatter(TaxCalculator);
            Orders.Add(order);
            Parcel.BundleHeader = summaryFormatter.PrintHeader(order.Recipient.Country);
            Parcel.BundlePrice += order.PaidAmount;
            Parcel.BundleTax += TaxCalculator.CalculateTax(order.PaidAmount);
            Parcel.BundlePriceWithTax += TaxCalculator.CalculateTax(order.PaidAmount) + order.PaidAmount;
            Parcel.Summary = summaryFormatter.PrintOrdersSummary(Orders);
        }

        public string GetLabelForOrder(IShippableOrder order)
        {
            return (new LabelFormatter()).GenerateLabelForOrder("LocalPost", order.Recipient);
        }

        public IEnumerable<IParcel> GetParcels()
        {
            yield return Parcel;
        }
    }
}