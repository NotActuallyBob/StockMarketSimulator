using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketSimulator
{
    public class Trader
    {
        static int nextTraderId = 0;

        Market market;
        int traderId;

        public Trader(Market market)
        {
            this.market = market;
            this.traderId = nextTraderId;
            nextTraderId++;
        }

        public void Buy(double price)
        {
            Order order = new Order(traderId, price);
            market.AddBuyBid(order);
        }

        public void Sell(double price)
        {
            Order order = new Order(traderId, price);
            market.AddSellBid(order);
        }
    }
}
