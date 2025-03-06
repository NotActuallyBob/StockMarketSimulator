using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketCore.Services
{
    public interface ITradableService
    {
        public List<Tradable> Get(int marketId);
        public void Add(Tradable tradable);
        public bool Exists(string ticker);
        public bool Exists(int id);
    }
}
