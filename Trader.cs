using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketSimulator
{
    public class Trader
    {
        Market market;

        public Trader(Market market)
        {
            this.market = market;
        }

        public void Buy(double price)
        {
            market.AddBuyBid(price);
        }

        public void Sell(double price)
        {
            market.AddSellBid(price);
        }
    }
}
