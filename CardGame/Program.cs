using System;
using System.Collections.Generic;

namespace CardGame
{
    class Program
    {
        static void Main(string[] args)
        {
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

            // Shuffle the deck
            Random rand = new Random();
            for (int i = 0; i < deck.Count; i++)
            {
                int j = rand.Next(deck.Count);
                string temp = deck[i];
                deck[i] = deck[j];
                deck[j] = temp;
            }

            // Deal 5 cards to the player

            // List<string> playerHand = new List<string>();
            // for (int i = 0; i < 5; i++)
            // {
            //     playerHand.Add(deck[i]);
            // }

            //Deal all cards to two players
            List<string> player1Hand = new List<string>();
            List<string> player2Hand = new List<string>();

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


            // Each plays one card
            string player1Card = player1Hand[0];
            string player2Card = player2Hand[0];

            System.Console.WriteLine($"Player 1 plays: {player1Card}");
            System.Console.WriteLine($"Player 2 plays: {player2Card}");

            // Determine the rank of the cards played
            int player1Rank = Array.IndexOf(ranks, player1Card.Split(' ')[0]);
            int player2Rank = Array.IndexOf(ranks, player2Card.Split(' ')[0]);


            // Determine the winner based on the rank of the cards
            if (player1Rank > player2Rank)
            {
                Console.WriteLine("Player 1 wins!");
            }
            else if (player1Rank < player2Rank)
            {
                Console.WriteLine("Player 2 wins!");
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }






            // Display the player's hand
            // Console.WriteLine("Player One's hand:");
            // foreach (string card in player1Hand)
            // {
            //     Console.WriteLine(card);
            // }

            // Display the remaining cards in the deck
            // Console.WriteLine("\nRemaining cards in the deck:");
            // for (int i = 5; i < deck.Count; i++)
            // {
            //     Console.WriteLine(deck[i]);
            // }
            System.Console.WriteLine("\nPress any key to exit...");
            Console.ReadLine(); // Wait for user input before closing the console
        }
    }
}