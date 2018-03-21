using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker
{
    class GameFlow
    {
        public PlayerInstance[] players;
        public int deckPos;
        public int chips;
        public int ids = 0;
        public Card[] Board = new Card[5];
        DeckOfCards clientDeck;
        public int boardState = 0;

        public int PotSize = 0;
        public int cardsShown = 0;
        public int totalPlayers = 2;
        public int currentPos = 0;

        public GameFlow(int amount, int chps)
        {
            players = new PlayerInstance[amount];
            chips = chps;
            //Game();
        }

        private Card NextCard()
        {
            Card card = new Card();
            try
            {
                card = clientDeck.GetDeck[deckPos];
                deckPos++;
            }
            catch (IndexOutOfRangeException) { card = null; }
            return card;
        }

        public PlayerInstance[] NewGame()
        {
            deckPos = 0;
            clientDeck = new DeckOfCards();
            clientDeck.InitDeck();

            for (int i = 0; i < 2; i++)
            {
                players[i] = new PlayerInstance();


                players[i].PlayerHand[0] = NextCard();
                players[i].PlayerHand[1] = NextCard();

            }

            return players;
        }

        public PlayerInstance[] NextTurnCheck(PlayerInstance[] playerHands)
        {
            currentPos = playerHands[0].TurnPosition;

            if (playerHands[currentPos].Checked == true)
            {
                currentPos++;
                if (currentPos >= totalPlayers)
                {
                    currentPos = 0;
                }

                foreach (PlayerInstance p in playerHands)
                    p.TurnPosition = currentPos;

                foreach (PlayerInstance p in playerHands)
                {
                    if (!p.Checked)
                        return playerHands;
                }



                foreach (PlayerInstance p in playerHands)
                {
                    p.DeckState++;
                    p.Checked = false;
                }
                boardState++;
                RefreshBoard();

            }

            return playerHands;
        }

        public PlayerInstance[] NextTurnRaise(PlayerInstance[] playerHands)
        {
            currentPos = playerHands[0].TurnPosition;

            PotSize += playerHands[currentPos].RaiseAmount;
            //////////////////////

            return playerHands;
        }


        public void RefreshBoard()
        {
            if (boardState == 1)
            {
                Board[0] = NextCard();
                Board[1] = NextCard();
                Board[2] = NextCard();
                cardsShown = 3;
            }
            if (boardState == 2)
            {
                Board[3] = NextCard();
                cardsShown = 4;
            }
            if (boardState == 3)
            {
                Board[4] = NextCard();
                cardsShown = 5;
            }
            if (boardState == 4)
            {
                //eval hands
                //boardState = 0;
            }
        }
    }
}
