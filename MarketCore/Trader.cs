using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketCore
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

        public void Buy(int tradableId, int quantity, double price)
        {
            Order order = new Order(traderId, tradableId, quantity, price, OrderType.Buy);
            market.AddOrder(order);
        }

        public void Sell(int tradableId, int quantity, double price)
        {
            Order order = new Order(traderId, tradableId, quantity, price, OrderType.Sell);
            market.AddOrder(order);
        }
    }
}
