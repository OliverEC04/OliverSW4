using System;

namespace StockPortfolio;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");

        List<Stock> stocks = new();
        stocks.Add(new Stock("Gamestop", 400));
        stocks.Add(new Stock("Palantir", 1));
        stocks.Add(new Stock("Novo Nordisk", 24357356));
        stocks.Add(new Stock("Norwegian", -532));

        Portfolio portfolioOliver = new(stocks[0]);
        portfolioOliver.AttachSubject(stocks[1]);
        portfolioOliver.AttachSubject(stocks[2]);
        portfolioOliver.AttachSubject(stocks[3]);

        PortfolioDisplay portfolioDisplay1 = new(portfolioOliver);

        while (true)
        {
            foreach (var stock in stocks)
            {
                stock.Refresh();
            }

            Thread.Sleep(1000);
        }
    }
}