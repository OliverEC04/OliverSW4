namespace StockPortfolio;

public class StockData
{
    public int Value { get; set; }
}

public class Stock<T> : ISubject<T>
{
    private List<IObserver<T>> _observers = new();
    private T _state;

    public Stock(T state)
    {
        _state = state;
    }

    public void Attach(IObserver<T> observer)
    {
        _observers.Add(observer);
    }

    public void Detach(IObserver<T> observer)
    {
        _observers.Remove(observer);
    }

    public void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_state);
        }
    }
}