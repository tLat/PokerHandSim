using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Poker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// 
        //CardServer newServer;
        //CardClient newClient;

        /// 
        Ranks RankName = new Ranks();
        DeckOfCards clientDeck;
        Card[] clientHand = new Card[2];
        Card cardBuffer = new Card();
        Card[] p1_hand = new Card[2];
        private const string folder = "png/";

        Card[] dealer = new Card[5];
        CardMatch Matcher = new CardMatch();
        EvalHand Eval = new EvalHand();

        PlayerInstance[] hands = new PlayerInstance[2];

        GameFlow Game;

        int[] rank = { 0, 0, 0 };
        int[] opp_rank = { 0, 0, 0 };
        int whoWon = 0;

        int deckPos = 0;
        int cardsShown = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWin_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            //ButtonFlop.IsEnabled = true;
            //ButtonTurn.IsEnabled = true;
            //ButtonRiver.IsEnabled = true;
            deal1.Source = null;
            deal2.Source = null;
            deal3.Source = null;
            deal4.Source = null;
            deal5.Source = null;

            Game = new GameFlow(2, 1000);
            hands = Game.NewGame();

            p1Check.Visibility = Visibility.Visible;
            ButtonEnd.Visibility = Visibility.Visible;


            hands[0].PlayerHand = new CardSort().Order(hands[0].PlayerHand);
            hands[1].PlayerHand = new CardSort().Order(hands[1].PlayerHand);


            //Console.WriteLine("Your Hand");
            //Console.WriteLine(clientHand[0].Value.ToString() + " of " + clientHand[0].Suit.ToString());
            //Console.WriteLine(clientHand[1].Value.ToString() + " of " + clientHand[1].Suit.ToString());

            hand1.Source = new BitmapImage(new Uri(folder + Matcher.Match(hands[0].PlayerHand[0]), UriKind.Relative));
            hand2.Source = new BitmapImage(new Uri(folder + Matcher.Match(hands[0].PlayerHand[1]), UriKind.Relative));

            opp_hand1.Source = new BitmapImage(new Uri(folder + Matcher.Match(hands[1].PlayerHand[0]), UriKind.Relative));
            opp_hand2.Source = new BitmapImage(new Uri(folder + Matcher.Match(hands[1].PlayerHand[1]), UriKind.Relative));


            cardsShown = 0;

            hand1Status.Text = "";
            hand2Status.Text = "";
            DisplayText.Text = "";
            rect1.Visibility = rect2.Visibility = Visibility.Hidden;
        }

        private Card NextCard()
        {
            Card card = new Card();
            try
            {
                card = clientDeck.GetDeck[deckPos];
                deckPos++;
            }
            catch (IndexOutOfRangeException)
            {
                card = null;
            }
            return card;
        }

        private void StopDraws()
        {
            Console.WriteLine("Deck out of cards");
            //ButtonFlop.IsEnabled = false;
            //ButtonTurn.IsEnabled = false;
            //ButtonRiver.IsEnabled = false;
        }

        private void Flop()
        {
            cardsShown = 3;
            dealer[0] = NextCard();
            
            dealer[1] = NextCard();
            
            dealer[2] = NextCard();
            

            Console.WriteLine("Flop");
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine(dealer[i].Value.ToString() + " of " + dealer[i].Suit.ToString());
            }

            deal1.Source = new BitmapImage(new Uri(folder + Matcher.Match(dealer[0]), UriKind.Relative));
            deal2.Source = new BitmapImage(new Uri(folder + Matcher.Match(dealer[1]), UriKind.Relative));
            deal3.Source = new BitmapImage(new Uri(folder + Matcher.Match(dealer[2]), UriKind.Relative));

            rank = Eval.Evaluate(hands[0].PlayerHand, Game.Board, Game.cardsShown);
            opp_rank = Eval.Evaluate(hands[1].PlayerHand, Game.Board, Game.cardsShown);
            Console.WriteLine(rank[0] + " " + rank[1] + " " + rank[2]);
        }

        private void Turn()
        {
            cardsShown = 4;
            dealer[3] = NextCard();

            Console.WriteLine("Turn");
            Console.WriteLine(dealer[3].Value.ToString() + " of " + dealer[3].Suit.ToString());
            deal4.Source = new BitmapImage(new Uri(folder + Matcher.Match(dealer[3]), UriKind.Relative));

            rank = Eval.Evaluate(hands[0].PlayerHand, Game.Board, Game.cardsShown);
            opp_rank = Eval.Evaluate(hands[1].PlayerHand, Game.Board, Game.cardsShown);
            Console.WriteLine(rank[0] + " " + rank[1] + " " + rank[2]);
        }

        private void River()
        {
            cardsShown = 5;
            cardBuffer = NextCard();
            if (cardBuffer == null)
                StopDraws();
            else
            {
                dealer[4] = cardBuffer;
                Console.WriteLine("River");
                Console.WriteLine(dealer[4].Value.ToString() + " of " + dealer[4].Suit.ToString());
                deal5.Source = new BitmapImage(new Uri(folder + Matcher.Match(dealer[4]), UriKind.Relative));

                rank = Eval.Evaluate(hands[0].PlayerHand, Game.Board, Game.cardsShown);
                opp_rank = Eval.Evaluate(hands[1].PlayerHand, Game.Board, Game.cardsShown);
                Console.WriteLine(rank[0] + " " + rank[1] + " " + rank[2]);
            }
        }

        private void ButtonTurn_Click(object sender, RoutedEventArgs e)
        {
            Turn();
        }

        private void ButtonRiver_Click(object sender, RoutedEventArgs e)
        {
            River();
        }

        private void ButtonFlop_Click(object sender, RoutedEventArgs e)
        {
            Flop();
        }

        private void ButtonEnd_Click(object sender, RoutedEventArgs e)
        {
            rank = Eval.Evaluate(hands[0].PlayerHand, Game.Board, Game.cardsShown);
            opp_rank = Eval.Evaluate(hands[1].PlayerHand, Game.Board, Game.cardsShown);
            //StopDraws();

            if (rank[0] > opp_rank[0])
            {
                WriteToDisplay("You WIN with " + RankName.getString(rank[0]));
                whoWon = 1;
            }
            else if (rank[0] == opp_rank[0])
            {
                if (rank[1] > opp_rank[1])
                {
                    WriteToDisplay("You WIN with your higher " + RankName.getString(rank[0]));
                    whoWon = 1;
                }
                else if (rank[1] == opp_rank[1])
                {
                    if (rank[2] > opp_rank[2])
                    {
                        WriteToDisplay("You WIN with your higher " + RankName.getString(rank[0]));
                        whoWon = 1;
                    }
                    else if (rank[2] == opp_rank[2])
                    {
                        WriteToDisplay("You SPLIT the POT with " + RankName.getString(rank[0]));
                        whoWon = 0;
                    }
                }
                else
                {
                    WriteToDisplay("You LOSE with your lower " + RankName.getString(rank[0]));
                    whoWon = 2;
                }
                    

            }
            else
            {
                WriteToDisplay("You LOSE to " + RankName.getString(opp_rank[0]));
                whoWon = 2;
            }


            UpdateWinRectangle();
            UpdateRankText();
        }

        private void UpdateRankText()
        {
            hand1Status.Text = RankName.getString(rank[0]) + " (With value " + rank[1].ToString() + ")";
            hand2Status.Text = RankName.getString(opp_rank[0]) + " (With value " + opp_rank[1].ToString() + ")";
        }

        private void UpdateWinRectangle()
        {
            if (whoWon == 1)
            {
                rect1.Visibility = Visibility.Visible;
                rect2.Visibility = Visibility.Hidden;
            }
            else if (whoWon == 2)
            {
                rect2.Visibility = Visibility.Visible;
                rect1.Visibility = Visibility.Hidden;
            }
            else
            {
                rect1.Visibility = Visibility.Hidden;
                rect2.Visibility = Visibility.Hidden;
            }

        }

        private void Button_Server_Click(object sender, RoutedEventArgs e)
        {
            //newServer = new CardServer();
            //newServer.Start();
        }

        private void Button_Client_Click(object sender, RoutedEventArgs e)
        {
            //newClient = new CardClient();
            //newClient.Start();
        }

        private void ServerEnd_Click(object sender, RoutedEventArgs e)
        {
            //newServer.EndServer();
        }

        private void ClientEnd_Click(object sender, RoutedEventArgs e)
        {
            //newClient.Exit();
        }

        private void p1Check_Click(object sender, RoutedEventArgs e)
        {
            hands[0].Checked = true;
            Game.NextTurnCheck(hands);
            NextTurn_Rfsh();
            CheckMove();

            hands[1].Checked = true;
            Game.NextTurnCheck(hands);
            NextTurn_Rfsh();
            CheckMove();

            rect1.Visibility = rect2.Visibility = Visibility.Hidden;
        }

        private void p2Check_Click(object sender, RoutedEventArgs e)
        {
            hands[1].Checked = true;
            Game.NextTurnCheck(hands);
            NextTurn_Rfsh();
            CheckMove();
        }

        private void NextTurn_Rfsh()
        {
            

            if (Game.Board[0] != null)
            {
                deal1.Source = new BitmapImage(new Uri(folder + Matcher.Match(Game.Board[0]), UriKind.Relative));
                deal2.Source = new BitmapImage(new Uri(folder + Matcher.Match(Game.Board[1]), UriKind.Relative));
                deal3.Source = new BitmapImage(new Uri(folder + Matcher.Match(Game.Board[2]), UriKind.Relative));

                if (Game.Board[3] != null)
                {
                    deal4.Source = new BitmapImage(new Uri(folder + Matcher.Match(Game.Board[3]), UriKind.Relative));

                    if (Game.Board[4] != null)
                        deal5.Source = new BitmapImage(new Uri(folder + Matcher.Match(Game.Board[4]), UriKind.Relative));
                }
            }

            if (Game.boardState == 4)
            {
                rank = Eval.Evaluate(hands[0].PlayerHand, Game.Board, Game.cardsShown);
                opp_rank = Eval.Evaluate(hands[1].PlayerHand, Game.Board, Game.cardsShown);

                if (rank[0] > opp_rank[0])
                {
                    WriteToDisplay("You WIN with " + RankName.getString(rank[0]));
                }
                else if (rank[0] == opp_rank[0])
                {
                    if (rank[1] > opp_rank[1])
                    {
                        WriteToDisplay("You WIN with your higher " + RankName.getString(rank[0]));
                    }
                    else if (rank[1] == opp_rank[1])
                    {
                        if (rank[2] > opp_rank[2])
                        {
                            WriteToDisplay("You WIN with your higher " + RankName.getString(rank[0]));
                        }
                        else if (rank[2] == opp_rank[2])
                        {
                            WriteToDisplay("You SPLIT the POT with " + RankName.getString(rank[0]));
                        }
                    }
                    else
                        WriteToDisplay("You LOSE with your lower " + RankName.getString(rank[0]));

                }
                else
                    WriteToDisplay("You LOSE to " + RankName.getString(opp_rank[0]));
            }
        }

        private void CheckMove()
        {
            if (hands[0].Checked)
                hand1Status.Text = "Checked";
            else
                hand1Status.Text = "";

            if (hands[1].Checked)
                hand2Status.Text = "Checked";
            else
                hand2Status.Text = "";
        }

        private void p1Raise_Click(object sender, RoutedEventArgs e)
        {
            hands[0].Raised = true;
            hands[0].RaiseAmount = 100;
            hands[0].Chips -= 100;
            hands[0].PotSize += 100;
            //Game
            CheckMove();
        }

        private void WriteToDisplay(string s)
        {
            Console.WriteLine(s);
            DisplayText.Text = s;
        }
    }
}
