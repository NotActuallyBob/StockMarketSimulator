using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketCore.Services
{
    public class TradeService : ITradeService
    {
        private readonly AppDbContext context;

        public TradeService(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Trade trade)
        {
            context.Trades.Add(trade);
        }
    }
}
