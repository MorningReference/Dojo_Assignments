using System;
using System.Collections.Generic;

namespace DeckOfCards
{
    public class Player
    {
        public string Name;
        public List<Card> Hand;
        public Player(string name)
        {
            Name = name;
            Hand = new List<Card>{};
        }

        public Card Draw(Deck deck)
        {
            Card cardDrawn = deck.Deal();
            Hand.Add(cardDrawn);
            Console.WriteLine($"{Name} has drawn a {cardDrawn.StringVal} of {cardDrawn.Suit}.");
            return cardDrawn;
        }
        public Card Discard(int index)
        {
            if(Hand[index] == null)
                return null;
            Card cardDiscard = Hand[index];
            Hand.RemoveAt(index);
            Console.WriteLine($"{Name} has discarded {cardDiscard.StringVal} of {cardDiscard.Suit}.");
            return cardDiscard;
        }
    }
}