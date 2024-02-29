using System;

namespace StockPortfolio;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");

        Stock<StockData> stock1 = new Stock<StockData>(new StockData());
        Portfolio<PortfolioData> portfolio1 = new Portfolio<PortfolioData>(stock1, new PortfolioData());
    }
}