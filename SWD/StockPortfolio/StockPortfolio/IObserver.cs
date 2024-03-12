namespace StockPortfolio;

public interface IObserver<T>
{
    /// <summary>
    /// Attach a subject to be observed by this class.
    /// </summary>
    /// <param name="subject">Subject to be observed.</param>
    void AttachSubject(ISubject<T> subject);
    
    /// <summary>
    /// Detach a subject currently being observed by this class.
    /// </summary>
    /// <param name="subject">Subject no longer to be observed.</param>
    void DetachSubject(ISubject<T> subject);
    
    /// <summary>
    /// Called by the subject whenever a change occurs to the subject's data.
    /// </summary>
    /// <param name="subjectData">New subject data.</param>
    void Update(T subjectData);
}