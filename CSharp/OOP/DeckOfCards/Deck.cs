using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class Deck
    {
        private List<Card> cards;

        public Deck()
        {
            cards = new List<Card>{};
            string stringVal = "";
            string suit = "Spades";
            int val = 0;
            for (int i = 1; i <= 52; i++)
            {
                if(i%13 == 0)
                    val = 13;
                else
                    val = i%13;

                if(val == 1)
                    stringVal = "Ace";
                else if(val == 11)
                    stringVal = "Jack";
                else if(val == 12)
                    stringVal = "Queen";
                else if(val == 13)
                    stringVal = "King";
                else
                    stringVal = val.ToString();

                if(i%13 == 0 && i/13 == 1)
                    suit = "Clubs";
                else if(i%13 == 0 && i/13 == 2)
                    suit = "Hearts";
                else if(i%13 == 0 && i/13 == 3)
                    suit = "Diamonds";

                cards.Add(new Card(stringVal, suit, val));
                Console.WriteLine($"Creating {stringVal} of {suit} with the value of {val}.");
            }
        }

        public Card Deal()
        {
            Card cardToRemove = cards[0];
            cards.RemoveAt(0);
            return cardToRemove;
        }

        public void Reset()
        {
            cards = new List<Card>{};
            string stringVal = "";
            string suit = "Spades";
            int val = 0;
            for (int i = 1; i <= 52; i++)
            {
                if(i%13 == 0)
                    val = 13;
                else
                    val = i%13;

                if(val == 1)
                    stringVal = "Ace";
                else if(val == 11)
                    stringVal = "Jack";
                else if(val == 12)
                    stringVal = "Queen";
                else if(val == 13)
                    stringVal = "King";
                else
                    stringVal = val.ToString();

                if(i%13 == 0 && i/13 == 1)
                    suit = "Clubs";
                else if(i%13 == 0 && i/13 == 2)
                    suit = "Hearts";
                else if(i%13 == 0 && i/13 == 3)
                    suit = "Diamonds";

                cards.Add(new Card(stringVal, suit, val));
            }
        }

        public void Shuffle()
        {
            int count = cards.Count;
            Random rand = new Random();
            Card temp;
            while(count > 1)
            {
                count--;
                int shuffleIndex = rand.Next(count+1);
                temp = cards[shuffleIndex];
                cards[shuffleIndex] = cards[count];
                cards[count] = temp;
            }
        }

    }
}