using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    [SerializableAttribute]
    public class PlayerInstance
    {
        public int TotalPlayers { get; set; } = 2;
        public int TurnPosition { get; set; } = 0;
        //public int[] PlayerStatus { get; set; }  // [id, callraisefolded, chips, chips wagered] 
        public int DeckState { get; set; } = 0;

        public int Chips { get; set; } = 1000;
        public Card[] PlayerHand = new Card[2];
        public int PlayerID { get; set; } = -1;
        public bool Folded { get; set; } = false;
        public bool Called { get; set; } = false;
        public bool Raised { get; set; } = false;
        public bool Checked { get; set; } = false;
        public int RaiseAmount { get; set; } = 0;
        public int PotSize { get; set; } = 0;

            

    }
}
