using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class Player
    {
        public Card[] Cards { get; } // man kan kun get array, men ændre hver element
        public string Name { get; }

        public Player(string name)
        {
            Name = name;
        }

        public IEnumerable<Card> GetCards()
        {
            foreach (Card card in Cards)
            {
                yield return card;
            }
        }

        public void AddCard(Card card)
        {
            Cards.Append(card);
        }
    }
}
