namespace StockPortfolio;

public class PortfolioDisplay : IObserver<PortfolioData>
{
    public PortfolioDisplay(ISubject<PortfolioData> subject)
    {
        AttachSubject(subject);
    }

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
        Console.Clear();
        Console.WriteLine("Portfolio overview:");
        
        foreach (var x in subjectData.Stocks)
        {
            Console.WriteLine($"{x.Item1}: {x.Item2}");
        }
    }
}