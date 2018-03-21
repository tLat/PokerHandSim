using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class DeckOfCards: Card
    {
        Card[] Deck = new Card[52];
        public Card[] GetDeck { get { return Deck; } }
        


        public void InitDeck()
        {
            int i = 0;
            foreach(SUIT s in Enum.GetValues(typeof(SUIT)))
            {
                foreach(VALUE v in Enum.GetValues(typeof(VALUE)))
                {
                    Deck[i] = new Card { Suit = s, Value = v };
                    i++;
                }
            }
            Shuffle();
        }

        public void Shuffle()
        {
            var rand = new Random();
            Card hold;

            for (int shuffleCount = 0; shuffleCount < 1776; shuffleCount++)
            {
                for (int i = 0; i < 52; i++)
                {
                    int index = rand.Next(52);
                    hold = Deck[i];
                    Deck[i] = Deck[index];
                    Deck[index] = hold;
                }
            }
        }

    }
}
