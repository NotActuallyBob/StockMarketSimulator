using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketCore.Services
{
    public class OrderService : IOrderService
    {
        private readonly AppDbContext context;

        public OrderService(AppDbContext context)
        {
            this.context = context;
        }

        public void AddOrder(Order order)
        {
            if (order == null)
            {
                return;
            }

            context.Orders.Add(order);
            context.SaveChanges();
        }
        public void RevokeOrder(Order order)
        {
            if(order == null)
            {
                return;
            }

            order.Revoke();
            context.SaveChanges();
        }

        public void RemoveOrder(Order order)
        {
            if(order == null)
            {
                return;
            }

            context.Orders.Remove(order);
            context.SaveChanges();
        }

        public List<Order> GetBuyOrders(int tradableId)
        {
            return context.BuyOrders.Where(x => x.TradableId == tradableId).ToList();
        }

        public List<Order> GetSellOrders(int tradableId)
        {
            return context.SellOrders.Where(x => x.TradableId == tradableId).ToList();
        }

        private bool Exists(int id)
        {
            if (context.Orders.FirstOrDefault(x => x.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public void PartlyFullfill(Order order, int fullfilledQuantity)
        {
            if (!Exists(order.Id))
            {
                return;
            }

            order.Quantity -= fullfilledQuantity;

            context.SaveChanges();
        }
    }
}
