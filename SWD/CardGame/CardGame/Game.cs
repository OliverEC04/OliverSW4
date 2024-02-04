using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    internal class Game
    {
        private readonly Deck _deck;
        private readonly List<Player> _players = [];
        
        public Game(int cardCount)
        {
            _deck = new Deck(cardCount);
        }

        public Player AddPlayer(string name)
        {
            Player player = new Player(name);
            _players.Add(player);
            return player;
        }

        public void Begin()
        {
            int cardsPerPlayer = (int)Math.Floor((decimal) _deck.CardCount / _players.Count);

            foreach (Player player in _players)
            {
                _deck.DealerBot(cardsPerPlayer, player);
            }

            Console.WriteLine($"Dealt each of the {_players.Count} players {cardsPerPlayer} cards.");
        }

        public Player GetWinner()
        {
            Player winner = _players[0];
            
            foreach (Player player in _players)
            {
                if (player.GetHandValue() > winner.GetHandValue())
                {
                    winner = player;
                }
            }

            return winner;
        }
    }
}
