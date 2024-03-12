namespace StockPortfolio;

public class StockData
{
    public string Name { get; set; }
    public int Value { get; set; }
}

public class Stock : ISubject<StockData>
{
    private List<IObserver<StockData>> _observers = new();
    private StockData _state = new();

    public Stock(string name, int initValue)
    {
        _state.Name = name;
        _state.Value = initValue;
    }

    #region SubjectMethods
    public void AttachObserver(IObserver<StockData> observer)
    {
        _observers.Add(observer);
        observer.Update(_state);
    }

    public void DetachObserver(IObserver<StockData> observer)
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

    /// <summary>
    /// Updates value of the stock with some randomness, and notifies observers.
    /// </summary>
    public void Refresh()
    {
        var rnd = new Random();
        
        if (_state.Value < 1)
            _state.Value += rnd.Next(0, 10) == 10 ? 1 : 0;
        
        _state.Value = (int)Math.Ceiling((float)rnd.Next(96, 105) / 100 * _state.Value);
        
        NotifyObservers();
    }
}