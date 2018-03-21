using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class CardMatch : Card
    {
        public string Match(Card card)
        {

            #region spades
            if (card.Suit == SUIT.SPADES && card.Value == VALUE.TWO)
                return "2S.png";
            if (card.Suit == SUIT.SPADES && card.Value == VALUE.THREE)
                return "3S.png";
            if (card.Suit == SUIT.SPADES && card.Value == VALUE.FOUR)
                return "4S.png";
            if (card.Suit == SUIT.SPADES && card.Value == VALUE.FIVE)
                return "5S.png";
            if (card.Suit == SUIT.SPADES && card.Value == VALUE.SIX)
                return "6S.png";
            if (card.Suit == SUIT.SPADES && card.Value == VALUE.SEVEN)
                return "7S.png";
            if (card.Suit == SUIT.SPADES && card.Value == VALUE.EIGHT)
                return "8S.png";
            if (card.Suit == SUIT.SPADES && card.Value == VALUE.NINE)
                return "9S.png";
            if (card.Suit == SUIT.SPADES && card.Value == VALUE.TEN)
                return "10S.png";
            if (card.Suit == SUIT.SPADES && card.Value == VALUE.JACK)
                return "JS.png";
            if (card.Suit == SUIT.SPADES && card.Value == VALUE.QUEEN)
                return "QS.png";
            if (card.Suit == SUIT.SPADES && card.Value == VALUE.KING)
                return "KS.png";
            if (card.Suit == SUIT.SPADES && card.Value == VALUE.ACE)
                return "AS.png";
            #endregion

            #region clubs
            if (card.Suit == SUIT.CLUBS && card.Value == VALUE.TWO)
                return "2C.png";
            if (card.Suit == SUIT.CLUBS && card.Value == VALUE.THREE)
                return "3C.png";
            if (card.Suit == SUIT.CLUBS && card.Value == VALUE.FOUR)
                return "4C.png";
            if (card.Suit == SUIT.CLUBS && card.Value == VALUE.FIVE)
                return "5C.png";
            if (card.Suit == SUIT.CLUBS && card.Value == VALUE.SIX)
                return "6C.png";
            if (card.Suit == SUIT.CLUBS && card.Value == VALUE.SEVEN)
                return "7C.png";
            if (card.Suit == SUIT.CLUBS && card.Value == VALUE.EIGHT)
                return "8C.png";
            if (card.Suit == SUIT.CLUBS && card.Value == VALUE.NINE)
                return "9C.png";
            if (card.Suit == SUIT.CLUBS && card.Value == VALUE.TEN)
                return "10C.png";
            if (card.Suit == SUIT.CLUBS && card.Value == VALUE.JACK)
                return "JC.png";
            if (card.Suit == SUIT.CLUBS && card.Value == VALUE.QUEEN)
                return "QC.png";
            if (card.Suit == SUIT.CLUBS && card.Value == VALUE.KING)
                return "KC.png";
            if (card.Suit == SUIT.CLUBS && card.Value == VALUE.ACE)
                return "AC.png";
            #endregion

            #region diamonds
            if (card.Suit == SUIT.DIAMONDS && card.Value == VALUE.TWO)
                return "2D.png";
            if (card.Suit == SUIT.DIAMONDS && card.Value == VALUE.THREE)
                return "3D.png";
            if (card.Suit == SUIT.DIAMONDS && card.Value == VALUE.FOUR)
                return "4D.png";
            if (card.Suit == SUIT.DIAMONDS && card.Value == VALUE.FIVE)
                return "5D.png";
            if (card.Suit == SUIT.DIAMONDS && card.Value == VALUE.SIX)
                return "6D.png";
            if (card.Suit == SUIT.DIAMONDS && card.Value == VALUE.SEVEN)
                return "7D.png";
            if (card.Suit == SUIT.DIAMONDS && card.Value == VALUE.EIGHT)
                return "8D.png";
            if (card.Suit == SUIT.DIAMONDS && card.Value == VALUE.NINE)
                return "9D.png";
            if (card.Suit == SUIT.DIAMONDS && card.Value == VALUE.TEN)
                return "10D.png";
            if (card.Suit == SUIT.DIAMONDS && card.Value == VALUE.JACK)
                return "JD.png";
            if (card.Suit == SUIT.DIAMONDS && card.Value == VALUE.QUEEN)
                return "QD.png";
            if (card.Suit == SUIT.DIAMONDS && card.Value == VALUE.KING)
                return "KD.png";
            if (card.Suit == SUIT.DIAMONDS && card.Value == VALUE.ACE)
                return "AD.png";

            #endregion

            #region hearts

            if (card.Suit == SUIT.HEARTS && card.Value == VALUE.TWO)
                return "2H.png";
            if (card.Suit == SUIT.HEARTS && card.Value == VALUE.THREE)
                return "3H.png";
            if (card.Suit == SUIT.HEARTS && card.Value == VALUE.FOUR)
                return "4H.png";
            if (card.Suit == SUIT.HEARTS && card.Value == VALUE.FIVE)
                return "5H.png";
            if (card.Suit == SUIT.HEARTS && card.Value == VALUE.SIX)
                return "6H.png";
            if (card.Suit == SUIT.HEARTS && card.Value == VALUE.SEVEN)
                return "7H.png";
            if (card.Suit == SUIT.HEARTS && card.Value == VALUE.EIGHT)
                return "8H.png";
            if (card.Suit == SUIT.HEARTS && card.Value == VALUE.NINE)
                return "9H.png";
            if (card.Suit == SUIT.HEARTS && card.Value == VALUE.TEN)
                return "10H.png";
            if (card.Suit == SUIT.HEARTS && card.Value == VALUE.JACK)
                return "JH.png";
            if (card.Suit == SUIT.HEARTS && card.Value == VALUE.QUEEN)
                return "QH.png";
            if (card.Suit == SUIT.HEARTS && card.Value == VALUE.KING)
                return "KH.png";
            if (card.Suit == SUIT.HEARTS && card.Value == VALUE.ACE)
                return "AH.png";
            #endregion

            // if somehow no card matches
            return "";
        }

        public string CardToString(Card card)
        {
            #region spades
            if (card.Suit == SUIT.SPADES && card.Value == VALUE.TWO)
                return "2S";
            if (card.Suit == SUIT.SPADES && card.Value == VALUE.THREE)
                return "3S";
            if (card.Suit == SUIT.SPADES && card.Value == VALUE.FOUR)
                return "4S";
            if (card.Suit == SUIT.SPADES && card.Value == VALUE.FIVE)
                return "5S";
            if (card.Suit == SUIT.SPADES && card.Value == VALUE.SIX)
                return "6S";
            if (card.Suit == SUIT.SPADES && card.Value == VALUE.SEVEN)
                return "7S";
            if (card.Suit == SUIT.SPADES && card.Value == VALUE.EIGHT)
                return "8S";
            if (card.Suit == SUIT.SPADES && card.Value == VALUE.NINE)
                return "9S";
            if (card.Suit == SUIT.SPADES && card.Value == VALUE.TEN)
                return "10S";
            if (card.Suit == SUIT.SPADES && card.Value == VALUE.JACK)
                return "JS";
            if (card.Suit == SUIT.SPADES && card.Value == VALUE.QUEEN)
                return "QS";
            if (card.Suit == SUIT.SPADES && card.Value == VALUE.KING)
                return "KS";
            if (card.Suit == SUIT.SPADES && card.Value == VALUE.ACE)
                return "AS";
            #endregion

            #region clubs
            if (card.Suit == SUIT.CLUBS && card.Value == VALUE.TWO)
                return "2C";
            if (card.Suit == SUIT.CLUBS && card.Value == VALUE.THREE)
                return "3C";
            if (card.Suit == SUIT.CLUBS && card.Value == VALUE.FOUR)
                return "4C";
            if (card.Suit == SUIT.CLUBS && card.Value == VALUE.FIVE)
                return "5C";
            if (card.Suit == SUIT.CLUBS && card.Value == VALUE.SIX)
                return "6C";
            if (card.Suit == SUIT.CLUBS && card.Value == VALUE.SEVEN)
                return "7C";
            if (card.Suit == SUIT.CLUBS && card.Value == VALUE.EIGHT)
                return "8C";
            if (card.Suit == SUIT.CLUBS && card.Value == VALUE.NINE)
                return "9C";
            if (card.Suit == SUIT.CLUBS && card.Value == VALUE.TEN)
                return "10C";
            if (card.Suit == SUIT.CLUBS && card.Value == VALUE.JACK)
                return "JC";
            if (card.Suit == SUIT.CLUBS && card.Value == VALUE.QUEEN)
                return "QC";
            if (card.Suit == SUIT.CLUBS && card.Value == VALUE.KING)
                return "KC";
            if (card.Suit == SUIT.CLUBS && card.Value == VALUE.ACE)
                return "AC";
            #endregion

            #region diamonds
            if (card.Suit == SUIT.DIAMONDS && card.Value == VALUE.TWO)
                return "2D";
            if (card.Suit == SUIT.DIAMONDS && card.Value == VALUE.THREE)
                return "3D";
            if (card.Suit == SUIT.DIAMONDS && card.Value == VALUE.FOUR)
                return "4D";
            if (card.Suit == SUIT.DIAMONDS && card.Value == VALUE.FIVE)
                return "5D";
            if (card.Suit == SUIT.DIAMONDS && card.Value == VALUE.SIX)
                return "6D";
            if (card.Suit == SUIT.DIAMONDS && card.Value == VALUE.SEVEN)
                return "7D";
            if (card.Suit == SUIT.DIAMONDS && card.Value == VALUE.EIGHT)
                return "8D";
            if (card.Suit == SUIT.DIAMONDS && card.Value == VALUE.NINE)
                return "9D";
            if (card.Suit == SUIT.DIAMONDS && card.Value == VALUE.TEN)
                return "10D";
            if (card.Suit == SUIT.DIAMONDS && card.Value == VALUE.JACK)
                return "JD";
            if (card.Suit == SUIT.DIAMONDS && card.Value == VALUE.QUEEN)
                return "QD";
            if (card.Suit == SUIT.DIAMONDS && card.Value == VALUE.KING)
                return "KD";
            if (card.Suit == SUIT.DIAMONDS && card.Value == VALUE.ACE)
                return "AD";

            #endregion

            #region hearts

            if (card.Suit == SUIT.HEARTS && card.Value == VALUE.TWO)
                return "2H";
            if (card.Suit == SUIT.HEARTS && card.Value == VALUE.THREE)
                return "3H";
            if (card.Suit == SUIT.HEARTS && card.Value == VALUE.FOUR)
                return "4H";
            if (card.Suit == SUIT.HEARTS && card.Value == VALUE.FIVE)
                return "5H";
            if (card.Suit == SUIT.HEARTS && card.Value == VALUE.SIX)
                return "6H";
            if (card.Suit == SUIT.HEARTS && card.Value == VALUE.SEVEN)
                return "7H";
            if (card.Suit == SUIT.HEARTS && card.Value == VALUE.EIGHT)
                return "8H";
            if (card.Suit == SUIT.HEARTS && card.Value == VALUE.NINE)
                return "9H";
            if (card.Suit == SUIT.HEARTS && card.Value == VALUE.TEN)
                return "10H";
            if (card.Suit == SUIT.HEARTS && card.Value == VALUE.JACK)
                return "JH";
            if (card.Suit == SUIT.HEARTS && card.Value == VALUE.QUEEN)
                return "QH";
            if (card.Suit == SUIT.HEARTS && card.Value == VALUE.KING)
                return "KH";
            if (card.Suit == SUIT.HEARTS && card.Value == VALUE.ACE)
                return "AH";
            #endregion

            return "";
        }

        public Card StringToCard(string str)
        {
            Card card = new Card();
            int index = 0;

            #region Values
            if (str[index] == '1')
            {
                card.Value = VALUE.TEN;
                index++;
            }  
            if (str[index] == '2')
                card.Value = VALUE.TWO;
            if (str[index] == '3')
                card.Value = VALUE.THREE;
            if (str[index] == '4')
                card.Value = VALUE.FOUR;
            if (str[index] == '5')
                card.Value = VALUE.FIVE;
            if (str[index] == '6')
                card.Value = VALUE.SIX;
            if (str[index] == '7')
                card.Value = VALUE.SEVEN;
            if (str[index] == '8')
                card.Value = VALUE.EIGHT;
            if (str[index] == '9')
                card.Value = VALUE.NINE;
            if (str[index] == 'J')
                card.Value = VALUE.JACK;
            if (str[index] == 'Q')
                card.Value = VALUE.QUEEN;
            if (str[index] == 'K')
                card.Value = VALUE.KING;
            if (str[index] == 'A')
                card.Value = VALUE.ACE;
            #endregion

            #region Suits
            if (str[index + 1] == 'S')
                card.Suit = SUIT.SPADES;
            if (str[index + 1] == 'C')
                card.Suit = SUIT.CLUBS;
            if (str[index + 1] == 'D')
                card.Suit = SUIT.DIAMONDS;
            if (str[index + 1] == 'H')
                card.Suit = SUIT.HEARTS;
            #endregion

            return card;
        }
    }
}
