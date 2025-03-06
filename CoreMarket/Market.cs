using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketSimulator
{
    public class Market
    {
        Dictionary<int, List<Order>> buyOrders = new Dictionary<int, List<Order>>();
        Dictionary<int, List<Order>> sellOrders = new Dictionary<int, List<Order>>();

        List<int> tradables = new List<int>();
        List<Trade> trades = new List<Trade>();

        public Market()
        {
            AddTradable(1);
            AddTradable(2);
        }

        private void AddTradable(int tradableId)
        {
            if(tradables.Contains(tradableId))
            {
                return;
            }

            tradables.Add(tradableId);
            buyOrders[tradableId] = new List<Order>();
            sellOrders[tradableId] = new List<Order>();
        }

        public void AddBuyBid(Order order)
        {
            if(order == null || !tradables.Contains(order.TradableId))
            {
                return;
            }

            if (!buyOrders.ContainsKey(order.TradableId))
            {
                buyOrders[order.TradableId] = new List<Order>();
            }

            buyOrders[order.TradableId].Add(order);
        }

        public void AddSellBid(Order order)
        {
            if (order == null)
            {
                return;
            }

            if (!sellOrders.ContainsKey(order.TradableId))
            {
                sellOrders[order.TradableId] = new List<Order>();
            }

            sellOrders[order.TradableId].Add(order);
        }

        public void ResolveTrades()
        {
            foreach(int tradableId in tradables)
            {
                List<Order> tradablesBuyOrders = buyOrders[tradableId];
                List<Order> tradablesSellOrders = sellOrders[tradableId];

                tradablesSellOrders.Sort((a, b) => a.CompareTo(b));
                tradablesBuyOrders.Sort((a, b) => b.CompareTo(a));

                while (true)
                {
                    if (tradablesSellOrders.Count() == 0 || tradablesBuyOrders.Count() == 0 || tradablesSellOrders[0].Price > tradablesBuyOrders[0].Price)
                    {
                        break;
                    }

                    //We have a trade
                    trades.Add(new Trade(tradablesSellOrders[0], tradablesBuyOrders[0]));
                    tradablesBuyOrders.RemoveAt(0);
                    tradablesSellOrders.RemoveAt(0);
                }
            }
        }
    }
}
