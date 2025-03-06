using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketCore.Services
{
    public interface IOrderService
    {
        public List<Order> GetBuyOrders(int tradableId);
        public List<Order> GetSellOrders(int tradableId);
        public void PartlyFullfill(Order order, int fullfilledQuantity);
        public void AddOrder(Order order);
        public void RevokeOrder(Order order);
        public void RemoveOrder(Order order);
    }
}
