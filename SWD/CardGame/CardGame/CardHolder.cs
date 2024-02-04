namespace CardGame;

internal abstract class CardHolder
{
    protected readonly List<Card> Cards = [];
    
    public void AddCard(Card card)
    {
        Cards.Add(card);
    }
}