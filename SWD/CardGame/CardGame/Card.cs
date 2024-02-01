using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal enum Suit
    {
        Red = 1,
        Blue = 2,
        Green = 3,
        Yellow = 4
    }

    internal class Card
    {
        private readonly Suit _suit;
        private readonly int _num;

        public int Value
        {
            get
            {
                return Convert.ToInt32(_suit) * _num;
            }
        }

        public Card(Suit suit, int num)
        {
            _suit = suit;
            _num = num;
        }
    }
}
