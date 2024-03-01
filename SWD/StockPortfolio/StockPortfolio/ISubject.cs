namespace StockPortfolio;

public interface ISubject<T>
{
    void AttachObserver(IObserver<T> observer);
    void DetachObserver(IObserver<T> observer);
    void NotifyObservers();
}
