namespace CardGame;

internal class GoldCard : Card
{
    public int Value
    {
        get
        {
            return (int)Suit * (Num * 5);
        }
    }
}