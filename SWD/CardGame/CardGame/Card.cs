namespace CardGame;

internal enum Suit: int
{
    Red = 1,
    Blue = 2,
    Green = 3,
    Yellow = 4
}

internal class Card
{
    public Suit Suit { get; }
    public int Num { get; }
    
    public int Value
    {
        get
        {
            return (int)Suit * Num;
        }
    }

    public Card(): this(0,0)
    {}
    
    public Card(Suit suit, int num)
    {
        Random rnd = new Random();
        
        if (1 <= (int)suit && (int)suit <= 4)
        {
            Suit = suit;
        }
        else
        {
            Suit = (Suit)rnd.Next(1, 4);
        }

        if (1 <= num && num <= 8)
        {
            Num = num;
        }
        else
        {
            Num = rnd.Next(1, 8);
        }
    }
}
