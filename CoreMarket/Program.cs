

using StockMarketSimulator;

Market market = new Market();

Trader buyer = new Trader(market);
Trader buyer2 = new Trader(market);
Trader seller = new Trader(market);

buyer.Buy(-1, 5);
buyer2.Buy(1, 5);

seller.Sell(1, 3);

while (true)
{
    market.ResolveTrades();
}