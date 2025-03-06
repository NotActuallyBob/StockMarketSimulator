using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketSimulator
{
    public class Market
    {
        List<Order> buyOrders = new List<Order>();
        List<Order> sellOrders = new List<Order>();

        List<Trade> trades = new List<Trade>();

        public Market()
        {
            
        }

        public void AddBuyBid(Order order)
        {
            if(order == null)
            {
                return;
            }

            buyOrders.Add(order);
        }

        public void AddSellBid(Order order)
        {
            if (order == null)
            {
                return;
            }

            sellOrders.Add(order);
        }

        public void ResolveTrades()
        {
            sellOrders.Sort((a, b) => a.CompareTo(b));
            buyOrders.Sort((a, b) => b.CompareTo(a));

            while (true)
            {
                if (sellOrders.Count() == 0 || buyOrders.Count() == 0 || sellOrders[0].Price > buyOrders[0].Price)
                {
                    break;
                }

                //We have a trade
                trades.Add(new Trade(sellOrders[0], buyOrders[0]));
                buyOrders.RemoveAt(0);
                sellOrders.RemoveAt(0);
            }
        }
    }
}
