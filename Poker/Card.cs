using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    [SerializableAttribute]
    public class Card
    {
        public enum SUIT { SPADES, CLUBS, DIAMONDS, HEARTS}
        public enum VALUE { TWO = 2, THREE, FOUR,
                            FIVE, SIX, SEVEN, EIGHT,
                            NINE, TEN, JACK, QUEEN, KING, ACE}

        public SUIT Suit { get; set; }
        public VALUE Value { get; set; }
    }
}
