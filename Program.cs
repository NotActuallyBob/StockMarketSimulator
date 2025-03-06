

using StockMarketSimulator;

Market market = new Market();

Trader buyer = new Trader(market);
Trader seller = new Trader(market);

buyer.Buy(1);
buyer.Buy(2);
buyer.Buy(3);
buyer.Buy(4);
buyer.Buy(5);

seller.Sell(3);
seller.Sell(4);
seller.Sell(5);
seller.Sell(6);

while (true)
{
    market.ResolveTrades();
}