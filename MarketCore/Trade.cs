using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketCore
{
    public class Trade
    {
        [Key]
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public int SellerId { get; set; }
        public int TradableId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public Trade()
        {
            
        }

        public Trade(Order sellOrder, Order buyOrder, int quantity)
        {
            TradableId = sellOrder.TradableId;
            BuyerId = buyOrder.TraderId;
            SellerId = sellOrder.TraderId;
            Quantity = quantity;
            Price = sellOrder.Price;
        }
    }
}
