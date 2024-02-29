namespace StockPortfolio;

public class PortfolioData
{
    public int TotalValue { get; }
}

public class Portfolio<T> : IObserver<T>, ISubject<T>
{
    private List<IObserver<T>> _observers = new();
    private T _state;
    
    public Portfolio(ISubject<T> subject, T state)
    {
        subject.Attach(this);
        _state = state;
    }
    
    public void Update(T subjectData)
    {
        Console.WriteLine("hej obsss");
    }

    public void Attach(IObserver<T> observer)
    {
        throw new NotImplementedException();
    }

    public void Detach(IObserver<T> observer)
    {
        throw new NotImplementedException();
    }

    public void Notify()
    {
        throw new NotImplementedException();
    }
}