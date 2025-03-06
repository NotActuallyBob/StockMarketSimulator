using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketSimulator
{
    public class Market
    {
        List<double> sellPrices = new List<double>();
        List<double> buyPrices = new List<double>();
        List<double> trades = new List<double>();

        public Market()
        {
            
        }

        public void AddBuyBid(double price)
        {
            buyPrices.Add(price);
        }

        public void AddSellBid(double price)
        {
            sellPrices.Add(price);
        }

        public void ResolveTrades()
        {
            sellPrices.Sort((a, b) => a.CompareTo(b));
            buyPrices.Sort((a, b) => b.CompareTo(a));

            while (true)
            {
                if (sellPrices[0] > buyPrices[0])
                {
                    break;
                }

                //We have a trade
                trades.Add(sellPrices[0]);
                buyPrices.RemoveAt(0);
                sellPrices.RemoveAt(0);
            }
        }
    }
}
