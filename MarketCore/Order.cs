using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketCore
{
    public enum OrderType
    {
        Buy,
        Sell
    }

    public class Order : IComparable<Order>
    {
        [Key]
        public int Id { get; set; }
        public OrderType Type { get; set; }
        public bool Revoked { get; set; }
        public int TraderId { get; set; }
        public int TradableId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime EntryTime { get; set; }

        public void Revoke()
        {
            Revoked = true;
        }

        public Order()
        {
            
        }

        public Order(int traderId, int tradableId, int quantity, double price, OrderType type)
        {
            TraderId = traderId;
            TradableId = tradableId;
            Quantity = quantity;
            Price = price;
            EntryTime = DateTime.Now.ToUniversalTime();
            Type = type;
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
