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

        public void Buy(int tradableId, double price)
        {
            Order order = new Order(traderId, tradableId, price);
            market.AddBuyBid(order);
        }

        public void Sell(int tradableId, double price)
        {
            Order order = new Order(traderId, tradableId, price);
            market.AddSellBid(order);
        }
    }
}
