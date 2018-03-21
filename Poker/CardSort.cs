using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class CardSort: Card
    {
        public Card[] Order(Card[] unsorted)
        {
            if (unsorted[0].Value == unsorted[1].Value || unsorted[0].Value > unsorted[1].Value)
            {
                return unsorted;
            }
            else
            {
                Card hold = unsorted[0];
                unsorted[0] = unsorted[1];
                unsorted[1] = hold;
                return unsorted;
            }
            
        }

    }
}
