using MarketCore;
using MarketCore.Services;
using Microsoft.EntityFrameworkCore;

AppDbContext dbContext = new AppDbContext();

ITradableService tradablesService = new TradableService(dbContext);
IOrderService orderService = new OrderService(dbContext);
ITradeService tradeService = new TradeService(dbContext);

Market market = new Market(orderService, tradablesService, tradeService);

Trader buyer = new Trader(market);
Trader buyer2 = new Trader(market);
Trader seller = new Trader(market);

buyer.Buy(1, 2, 5);
buyer2.Buy(1, 5, 5);

seller.Sell(1, 6, 3);

while (true)
{
    market.ResolveTrades();
}