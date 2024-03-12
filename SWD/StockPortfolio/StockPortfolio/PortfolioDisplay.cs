namespace StockPortfolio;

public class PortfolioDisplay : IObserver<PortfolioData>
{
    private PortfolioData? _portfolioData;

    public PortfolioDisplay(ISubject<PortfolioData>? subject)
    {
        if (subject != null) AttachSubject(subject);
    }

    #region ObserverMethods

    public void AttachSubject(ISubject<PortfolioData> subject)
    {
        subject.AttachObserver(this);
    }

    public void DetachSubject(ISubject<PortfolioData> subject)
    {
        subject.DetachObserver(this);
    }

    public void Update(PortfolioData subjectData)
    {
        _portfolioData = subjectData;

        Display();
    }

    #endregion

    /// <summary>
    /// Displays the name and value for all stocks in the portfolio.
    /// </summary>
    private void Display()
    {
        Console.Clear();
        Console.WriteLine("Portfolio overview:");

        if (_portfolioData == null) return;
        foreach (var stockInfo in _portfolioData.Stocks)
        {
            Console.WriteLine($"{stockInfo.Item1}: {stockInfo.Item2}");
        }
    }
}