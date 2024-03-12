namespace StockPortfolio;

public class PortfolioData
{
    private List<Tuple<string, int>> _stocks = new();
    public List<Tuple<string, int>> Stocks => _stocks;
    public int TotalValue { get; set; }

    /// <summary>
    /// Updates info about a stock, or adds it if a stock with the given name doesn't exist.
    /// </summary>
    /// <param name="stockInfo">Tuple containing name and value of stock.</param>
    public void UpdateAddStock(Tuple<string, int> stockInfo)
    {
        _stocks.RemoveAll(s => s.Item1 == stockInfo.Item1);
        _stocks.Add(stockInfo);
    }
}

public class Portfolio : IObserver<StockData>, ISubject<PortfolioData>
{
    private List<IObserver<PortfolioData>> _observers = new();
    private PortfolioData _state = new PortfolioData();

    public Portfolio(ISubject<StockData>? subject)
    {
        if (subject != null) AttachSubject(subject);
    }

    #region SubjectMethods

    public void AttachObserver(IObserver<PortfolioData> observer)
    {
        _observers.Add(observer);
    }

    public void DetachObserver(IObserver<PortfolioData> observer)
    {
        _observers.Remove(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_state);
        }
    }

    #endregion

    #region ObserverMethods

    public void AttachSubject(ISubject<StockData> subject)
    {
        subject.AttachObserver(this);
    }

    public void DetachSubject(ISubject<StockData> subject)
    {
        subject.DetachObserver(this);
    }

    public void Update(StockData subjectData)
    {
        // Update info about stock, and notify observers
        _state.UpdateAddStock(Tuple.Create(subjectData.Name, subjectData.Value));
        NotifyObservers();
    }

    #endregion
}