using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        private readonly List<Stock> portfolio;

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
            portfolio = new List<Stock>();
        }

        public IReadOnlyCollection<Stock> Portfolio => this.portfolio;

        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        public decimal MoneyToInvest { get; set; }

        public string BrokerName { get; set; }

        public int Count => portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                portfolio.Add(stock);
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            var stock = FindStock(companyName);
            if (stock == null)
            {
                return $"{companyName} does not exist.";
            }

            if (sellPrice < stock.PricePerShare)
            {
                return $"Cannot sell {companyName}.";
            }

            portfolio.Remove(stock);
            MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            return portfolio.FirstOrDefault(x => x.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            return portfolio.OrderByDescending(x => x.MarketCapitalization).FirstOrDefault();
        }

        public string InvestorInformation()
        {
            StringBuilder info = new StringBuilder();
            info.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");
            portfolio.ForEach(x => info.AppendLine(x.ToString()));
            return info.ToString().TrimEnd();
        }

    }
}
