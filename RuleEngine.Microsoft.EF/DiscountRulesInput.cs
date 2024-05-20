using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuleEngine.Microsoft.EF
{
    public class BasicInfo
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string CreditHistory { get; set; }
        public string Country { get; set; }
        public int LoyaltyFactor { get; set; }
        public int TotalPurchasesToDate { get; set; }
    }

    public class OrderInfo
    {
        public int TotalOrders {  get; set; }
        public int RecurringItems {  get; set; }
    }
    
    public class TelemetryInfo
    {
        public int NoOfVisitsPerMonth {  get; set; }
        public int PercentageOfBuyingToVisit {  get; set; }
    }

    public class DiscountInfo
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Tier { get; set; }
    }
    public class DiscountRulesInput
    {
        public BasicInfo BasicInfo { get; set; }
        public OrderInfo OrderInfo { get; set; }
        public TelemetryInfo TelemetryInfo { get; set; }

        public DiscountInfo DiscountInfo { get; set; }
    }
}