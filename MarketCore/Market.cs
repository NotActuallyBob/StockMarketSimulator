using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketCore.Services;
using Microsoft.EntityFrameworkCore;

namespace MarketCore
{
    public class Market
    {
        int marketId = 0;

        private readonly IOrderService orderService;
        private readonly ITradableService tradablesService;
        private readonly ITradeService tradeService;

        public Market(IOrderService orderService, ITradableService tradablesService, ITradeService tradeService)
        {
            this.orderService = orderService;
            this.tradablesService = tradablesService;
            this.tradeService = tradeService;

            Tradable tradable1 = new Tradable("NESTE", marketId);
            Tradable tradable2 = new Tradable("KONE", marketId);
            tradablesService.Add(tradable1);
            tradablesService.Add(tradable2);
        }

        public void AddOrder(Order order)
        {
            if(order == null || !tradablesService.Exists(order.TradableId))
            {
                return;
            }

            orderService.AddOrder(order);
        }

        public void RevokeOrder(Order order)
        {
            if(order == null)
            {
                return;
            }

            orderService.RevokeOrder(order);
        }

        public void ResolveTrades()
        {
            List<Tradable> tradables = tradablesService.Get(marketId);
            foreach (Tradable tradable in tradables)
            {
                List<Order> tradablesBuyOrders = orderService.GetBuyOrders(tradable.Id);
                List<Order> tradablesSellOrders = orderService.GetSellOrders(tradable.Id);

                tradablesSellOrders.Sort((a, b) => a.CompareTo(b));
                tradablesBuyOrders.Sort((a, b) => b.CompareTo(a));

                while (true)
                {
                    if (tradablesSellOrders.Count() == 0 || tradablesBuyOrders.Count() == 0 || tradablesSellOrders[0].Price > tradablesBuyOrders[0].Price)
                    {
                        break;
                    }

                    Order buyOrder = tradablesBuyOrders[0];
                    Order sellOrder = tradablesSellOrders[0];

                    if(buyOrder.Quantity > sellOrder.Quantity)
                    {
                        tradeService.Add(new Trade(sellOrder, buyOrder, sellOrder.Quantity));
                        orderService.PartlyFullfill(buyOrder, sellOrder.Quantity);
                        tradablesSellOrders.RemoveAt(0);

                        orderService.RemoveOrder(sellOrder);
                    } else if (buyOrder.Quantity < sellOrder.Quantity)
                    {
                        tradeService.Add(new Trade(sellOrder, buyOrder, buyOrder.Quantity));
                        orderService.PartlyFullfill(sellOrder, buyOrder.Quantity);
                        tradablesBuyOrders.RemoveAt(0);

                        orderService.RemoveOrder(buyOrder);
                    } else
                    {
                        tradeService.Add(new Trade(sellOrder, buyOrder, sellOrder.Quantity));
                        tradablesBuyOrders.RemoveAt(0);
                        tradablesSellOrders.RemoveAt(0);

                        orderService.RemoveOrder(sellOrder);
                        orderService.RemoveOrder(buyOrder);
                    }
                }
            }
        }
    }
}
