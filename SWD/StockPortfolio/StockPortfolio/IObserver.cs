namespace StockPortfolio;

public interface IObserver<T>
{
    void AttachSubject(ISubject<T> subject);
    void DetachSubject(ISubject<T> subject);
    void Update(T subjectData);
}