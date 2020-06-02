using System;

namespace DeckOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Deck playingDeck = new Deck();
            Player player1 = new Player("Player1");
            Player player2 = new Player("Player2");
            Player player3 = new Player("Player3");
            Player player4 = new Player("Player4");
            playingDeck.Shuffle();
            playingDeck.Shuffle();

            for (int i = 0; i <= 7; i++)
            {
                player1.Draw(playingDeck);
                player2.Draw(playingDeck);
                player3.Draw(playingDeck);
                player4.Draw(playingDeck);
            }

        }
    }
}
