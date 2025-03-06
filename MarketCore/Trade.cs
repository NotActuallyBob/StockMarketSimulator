using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketSimulator.MarketCore
{
    internal class Trade
    {
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
        public int TradableId { get; set; }
        public double Price { get; set; }

        public Trade(Order sellOrder, Order buyOrder)
        {
            TradableId = sellOrder.TradableId;
            BuyerId = buyOrder.TraderId;
            SellerId = sellOrder.TraderId;
            Price = sellOrder.Price;
        }
    }
}
