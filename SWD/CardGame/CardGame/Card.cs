namespace CardGame;

internal enum Suit: int
{
    Red = 1,
    Blue = 2,
    Green = 3,
    Yellow = 4
}

internal sealed class Card
{
    private readonly Suit _suit;
    private readonly int _num;

    public Card(Suit suit, int num)
    {
        _suit = suit;
        _num = num;
    }

    public int Value
    {
        get
        {
            return (int)_suit * _num;
        }
    }
}
