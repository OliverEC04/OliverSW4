using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class Deck : CardHolder
    {
        public int CardCount { get; }
        
        public Deck(int cardCount)
        {
            CardCount = cardCount;
            
            for (int i = 0; i < CardCount; i++)
            {
                Cards.Add(new Card());
            }
        }
        
        public void DealerBot(int amount, Player player)
        {
            Random rnd = new Random();
            
            for (int i = 0; i < amount; i++)
            {
                player.AddCard(Cards[rnd.Next(0, Cards.Count)]);
            }
        }
    }
}
