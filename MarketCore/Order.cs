using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockMarketSimulator.MarketCore
{
    public class Order : IComparable<Order>
    {
        public int TraderId { get; set; }
        public int TradableId { get; set; }
        public double Price { get; set; }
        public DateTime EntryTime { get; set; }

        public Order(int traderId, int tradableId, double price)
        {
            TraderId = traderId;
            TradableId = tradableId;
            Price = price;
            EntryTime = DateTime.Now;
        }

        public int CompareTo(Order other)
        {
            int priceComparison = Price.CompareTo(other.Price);
            int timeComparison = EntryTime.CompareTo(other.EntryTime);

            if (priceComparison == 0)
            {
                return -timeComparison;
            }

            return priceComparison;
        }
    }
}
