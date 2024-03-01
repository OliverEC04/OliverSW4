namespace StockPortfolio;

public class PortfolioData
{
    private List<Tuple<string, int>> _stocks = new();
    public List<Tuple<string, int>> Stocks => _stocks;
    public int TotalValue { get; set; }

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

    public Portfolio(ISubject<StockData> subject)
    {
        AttachSubject(subject);
    }

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
        _state.UpdateAddStock(Tuple.Create(subjectData.Name, subjectData.Value));

        NotifyObservers();
    }
}