namespace StockPortfolio;

public interface ISubject<T>
{
    /// <summary>
    /// Attach an observer to be notified whenever a change occurs to this class's data.
    /// </summary>
    /// <param name="observer">Observer to be attached.</param>
    void AttachObserver(IObserver<T> observer);
    
    /// <summary>
    /// Detach an observer currently observing this class.
    /// </summary>
    /// <param name="observer">Observer to be detached.</param>
    void DetachObserver(IObserver<T> observer);
    
    /// <summary>
    /// Call this method when the class's data is changed, to notify the observers.
    /// </summary>
    void NotifyObservers();
}
