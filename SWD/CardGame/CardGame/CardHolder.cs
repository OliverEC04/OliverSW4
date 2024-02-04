namespace CardGame;

internal abstract class CardHolder
{
    protected int MaxCards = -1;
    protected readonly List<Card> Cards = [];
    
    public void AddCard(Card card)
    {
        Random rnd = new Random();
        
        if (Cards.Count >= MaxCards && MaxCards != -1)
        {
            Cards.RemoveAt(rnd.Next(0, Cards.Count));
        }
        
        Cards.Add(card);
    }
}