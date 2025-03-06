using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketCore.Services
{
    public class TradableService : ITradableService
    {
        private readonly AppDbContext context;

        public TradableService(AppDbContext context)
        {
            this.context = context;
        }

        public void Add(Tradable tradable)
        {
            if(Exists(tradable.Ticker))
            {
                return;
            }
            context.Tradables.Add(tradable);
            context.SaveChanges();
        }

        public bool Exists(string ticker)
        {
            if(context.Tradables.FirstOrDefault(x => x.Ticker == ticker) != null)
            {
                return true;
            }
            return false;
        }

        public bool Exists(int id)
        {
            if(context.Tradables.FirstOrDefault(x => x.Id == id) != null)
            {
                return true;
            }
            return false;
        }

        public List<Tradable> Get(int marketId)
        {
            return context.Tradables.Where(x => x.MarketId == marketId).ToList();
        }
    }
}
