using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketCore
{
    public class Tradable
    {
        [Key]
        public int Id { get; set; }
        public string Ticker { get; set; }
        public int MarketId { get; set; }

        public Tradable()
        {
            
        }

        public Tradable(string ticker, int marketId)
        {
            this.Ticker = ticker;
            this.MarketId = marketId;
        }
    }
}
