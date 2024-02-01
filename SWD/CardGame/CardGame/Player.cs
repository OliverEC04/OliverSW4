using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class Player
    {
        public Card[] Cards { get; }
        public string Name { get; }

        public Player(string name)
        {
            Name = name;
        }

        public void addCard(Card card)
        {
            Cards.Append(card);
        }
    }
}
