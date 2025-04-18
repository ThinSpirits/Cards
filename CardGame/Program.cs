using System;
using System.Collections.Generic;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
            // TODO: Extract the deck creation into separate method and class
            // Initialize the deck of cards
            List<string> deck = new List<string>();
            string[] suits = { "Hearts", "Diamonds", "Clubs", "Spades" };
            string[] ranks = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "Jack", "Queen", "King", "Ace" };

            foreach (string suit in suits)
            {
                foreach (string rank in ranks)
                {
                    deck.Add($"{rank} of {suit}");
                }
            }

            // TODO: Extract the shuffling into separate method
            // Shuffle the deck
            Random rand = new Random();
            for (int i = 0; i < deck.Count; i++)
            {
                int j = rand.Next(deck.Count);
                string temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }

            //TODO: Extract the dealing into separate method
            // Deal the cards to two players
            List<string> player1Hand = new List<string>();
            List<string> player2Hand = new List<string>();


            //TODO: Get total rounds played and put in proper spot
            int roundCount = 0;

            do
            {
                player1Hand.Add(deck[0]);
                deck.RemoveAt(0);
                if (deck.Count > 0)
                {
                    player2Hand.Add(deck[0]);
                    deck.RemoveAt(0);
                }
            }while (deck.Count > 0);

            Console.WriteLine($"Player One has {player1Hand.Count} cards.\nPlayer Two has {player2Hand.Count} cards");



            //TODO: Extract the game loop into a separate method
            //TODO: Add a way to exit the game if too many rounds are played


            // Game loop
            do
            {
                //TODO: Fix logic for each card being played, should not be a random assignment from the players hand

                // Each plays one card

                Random random = new Random();

                int player1CardIndex = random.Next(player1Hand.Count);
                int player2CardIndex = random.Next(player2Hand.Count);
                string player1Card = player1Hand[player1CardIndex];
                string player2Card = player2Hand[player2CardIndex];

                //System.Console.WriteLine($"Player 1 plays: {player1Card}. Player 2 plays: {player2Card}");

                // Determine the rank of the cards played
                int player1Rank = Array.IndexOf(ranks, player1Card.Split(' ')[0]);
                int player2Rank = Array.IndexOf(ranks, player2Card.Split(' ')[0]);


                //TODO: Display the cards played and winner of the round in a better format
                // Determine the winner based on the rank of the cards

                if (player1Rank > player2Rank)
                {
                    //Console.WriteLine("Player 1 wins this round!");
                    player1Hand.Add(player2Card);
                    player2Hand.Remove(player2Card);
                }
                else if (player1Rank < player2Rank)
                {
                    //Console.WriteLine("Player 2 wins this round!");
                    player2Hand.Add(player1Card);
                    player1Hand.Remove(player1Card);
                }
                else
                {
                    //TODO: Implement tie logic
                    //Console.WriteLine("It's a tie!");
                }
                Console.WriteLine($"Player One has {player1Hand.Count} cards. Player Two has {player2Hand.Count} cards");
                roundCount++;

                if (roundCount == 10)
                {
                    Console.WriteLine("10 Rounds have passed. Press any key to continue");
                    Console.ReadKey();
                    roundCount = 0;
                }

            } while (player1Hand.Count > 0 && player2Hand.Count > 0);

            // Determine the overall winner
            if (player1Hand.Count > player2Hand.Count)
            {
                Console.WriteLine("Player 1 wins the game!");
            }
            else if (player1Hand.Count < player2Hand.Count)
            {
                Console.WriteLine("Player 2 wins the game!");
            }



            Console.WriteLine("\nPress any key to exit...");
        }
    }
}