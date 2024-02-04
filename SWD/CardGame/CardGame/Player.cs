// man kan kun get array, men ændre hver element
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class Player : CardHolder
    {
        public string Name { get; }
        public bool Weak { get; } = false;

        public Player(string name)
        {
            Name = name;

            Random rnd = new Random();
            
            if (rnd.Next(0, 4) == 0)
            {
                Weak = true;
                MaxCards = 3;
            }
        }

        public int GetHandValue()
        {
            int value = 0;

            foreach (Card card in Cards)
            {
                value += card.Value;
            }

            return value;
        }
        
        public IEnumerable<Card> ShowHand()
        {
            foreach (Card card in Cards)
            {
                yield return card;
            }
        }
    }
}
