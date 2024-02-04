using System;

namespace CardGame
{
    internal class Program
    {
        Game _game = new Game(20);

        static void Main(string[] args)
        {
            Program p = new Program();
            
            p.StartMenu();
        }

        private void StartMenu()
        {
            Console.Clear();
            
            Console.WriteLine("p: add player");
            Console.WriteLine("g: begin game");
            Console.WriteLine("w: announce winner");

            switch (Console.ReadLine())
            {
                case "p":
                    PlayerMenu();
                    break;
                
                case "g":
                    DealtMenu();
                    break;
                
                case "w":
                    Console.WriteLine($"{_game.GetWinner().Name} won the game!");
                    break;
            }   
        }

        private void PlayerMenu()
        {
            Console.Clear();
            
            Console.WriteLine("Enter name: ");

            string name = Console.ReadLine();
            
            _game.AddPlayer(name);
            
            StartMenu();
        }

        private void DealtMenu()
        {
            Console.Clear();
            
            _game.Begin();
            
            Console.WriteLine("w: announce winner");
            
            switch (Console.ReadLine())
            {
                case "w":
                    Player winner = _game.GetWinner();
                    
                    Console.WriteLine($"{winner.Name} won the game!");
                    Console.WriteLine("The player had these cards on their hand:");
                    foreach (Card card in winner.ShowHand())
                    {
                        Console.Write($"[suit: {card.Suit}, number: {card.Num}, value: {card.Value}], ");
                    }
                    Console.WriteLine("");
                    break;
            }
        }
    }
}