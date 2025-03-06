using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketSimulator
{
    internal class Trade
    {
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
        public double Price { get; set; }

        public Trade(Order sellOrder, Order buyOrder)
        {
            BuyerId = buyOrder.TraderId;
            SellerId = sellOrder.TraderId;
            Price = sellOrder.Price;
        }
    }
}
