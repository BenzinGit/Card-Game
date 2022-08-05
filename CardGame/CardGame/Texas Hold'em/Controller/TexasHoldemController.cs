using CardGame.Point_System;
using CardGame.Texas_Hold_em.Model;
using CardGame.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Texas_Hold_em.Controller
{
    public class TexasHoldemController
    {
        private Deck deck;
        private int pot;
        private SharedCards sharedCards;

        private List<Player> players;
        private List<Player> activePlayers;


        private TexasHoldem view;

        private int points; 
        private int startingCash = 5000;
        private int bigBlind = 50;
        private int smallBlind = 25;
        private int cashToCall = 0;
        private int waitTime = 1000; 

        private Player currentPlayer;
        private Player currentDealer; 

        public TexasHoldemController(TexasHoldem view)
        {

            players = new List<Player>();
            activePlayers = new List<Player>(); 
            sharedCards = new SharedCards();    
            this.view = view;


        }

        public void PlayGame()
        {
            SetUpGame();

            while (true)
            {
                ResetRound(); 
                SetUpFirstRound();

                PlayBettingRound();
               
                
                DrawFlop();
                PrepareNextRound(); 
                currentPlayer = GetNextPlayer(currentDealer);
                PlayBettingRound();

                PrepareNextRound();
                currentPlayer = GetNextPlayer(currentDealer);
                DrawTurn();
                PlayBettingRound();

                PrepareNextRound();
                currentPlayer = GetNextPlayer(currentDealer);
                DrawRiver(); 
                PlayBettingRound();
                showAllPlayerCards(
                    );

                var winners = CardEvaluator.DecideWinner(activePlayers, sharedCards.GetCards());
                view.DisplayEndHands(players);
                AwardPot(winners);

                if (winners.Contains(players[0]))
                {
                    points = points + (players[0].EndHand.HandValue * 10);
                }

                view.UpdatePlayers(players);
                view.HighlightWinners(winners);

                Wait(waitTime * 8); 

            }

        }

        internal void SaveStats()
        {
            if (players.Count > 0)
            PointManager.SavePoints(points, players[0].Cash); 
        }

        private void ResetRound()
        {
            activePlayers.Clear();

            foreach (var player in players)
            {
                player.Bet = 0;
                player.HasFolded = false;
                player.IsPassive = false;




                if (player.Cash > 0)
                {
                    activePlayers.Add(player);
                }
                else
                {
                    view.SetCallSign("Out", players.IndexOf(currentPlayer));
                    player.IsBroke = true; 
                }
                

            }
            pot = 0;

            sharedCards.RemoveCards();

            view.ResetRound();


        }


        private void showAllPlayerCards()
        {

            for (int i = 0; i < activePlayers.Count; i++)
            {
                view.DisplayPlayerCards(activePlayers[i], activePlayers[i].HoleCards.Card1.Image, activePlayers[i].HoleCards.Card2.Image);
            }


        }


        private void AwardPot(List<Player> winners)
        {
            int winPotShare = pot / winners.Count;

            foreach (var player in winners)
            {
                player.Cash = player.Cash + winPotShare;
                Console.WriteLine(player.Name +": "+ player.EndHand.HandName);
            }

        }

        private void PrepareNextRound()
        {
            foreach (var player in players)
            {
                player.Bet = 0;
                view.RemoveBets();

                if (!player.HasFolded)
                {
                    player.IsPassive = false;
                    view.SetCallSign("", players.IndexOf(player));


                }
                if (player.Cash == 0)
                {
                    player.IsPassive = true;

                }

            }
            cashToCall = 0;

        }


        private void DrawFlop()
        {
            List<Card> cards = deck.DrawCards(3);
            sharedCards.SetFlop(cards);
            view.DisplayFlop(cards[0].Image, cards[1].Image, cards[2].Image);
        }
        private void DrawTurn()
        {
            Card turnCard = deck.DrawCard();
            sharedCards.SetTurn(turnCard);
            view.DisplayTurn(turnCard.Image);

        }

        private void DrawRiver()
        {
            Card riverCard = deck.DrawCard();
            sharedCards.SetRiver(riverCard);
            view.displayRiver(riverCard.Image);
        }


        private void PlayBettingRound()
        {
            Boolean allPassivePlayers = false;


            while (!allPassivePlayers)
            {
               
                if(activePlayers.Count == 1)
                {
                    return; 
                }

                view.HighlightPlayer(currentPlayer);

                int choice;
                if (currentPlayer.Ai != null)
                {
                    Wait(waitTime);

                    choice = currentPlayer.MakeDecision(cashToCall, pot, bigBlind, players, sharedCards.GetCards());

                }
                else
                {

                    choice = WaitForUserInput();

                }

                switch (choice)
                {

                    case -1: Fold(); break;

                    case 1:  Call(); break;
                    
                    default: Raise(choice); break; 
                }



                view.UpdatePot(pot);
                view.UpdatePlayers(players);
                
                if (currentPlayer.Ai != null)
                    Wait(waitTime);

                currentPlayer = GetNextPlayer(currentPlayer);


                allPassivePlayers = true;
                foreach (var player in activePlayers)
                {
                    if (!player.IsPassive)
                    {
                        allPassivePlayers = false;
                    }
                }

            }

        }

        private void Raise(int raise)
        {
            int bet = currentPlayer.Bet;

            if (currentPlayer.Cash < cashToCall)
            {
                currentPlayer.Raise(currentPlayer.Cash);
            }
            else
            {
                currentPlayer.Raise(raise);
            }


            cashToCall = currentPlayer.Bet;
            pot = pot + currentPlayer.Bet - bet;

            view.SetCallSign("Raise", players.IndexOf(currentPlayer));

            foreach (var player in activePlayers)
            {
                    player.IsPassive = false;
                
            }
            currentPlayer.IsPassive = true;


        }

        private void Fold()
        {
            currentPlayer.Fold();
            view.SetCallSign("Fold", players.IndexOf(currentPlayer));
        //    view.FoldPlayer(currentPlayer); 

            activePlayers.Remove(currentPlayer);
        }

        private void Call()
        {
            if (cashToCall == currentPlayer.Bet)
            {
                view.SetCallSign("Check", players.IndexOf(currentPlayer));

            }
            else
            {
                view.SetCallSign("Call", players.IndexOf(currentPlayer));

            }

            int bet = currentPlayer.Bet;
            if (currentPlayer.Cash < cashToCall)
            {
                currentPlayer.Call(currentPlayer.Cash);
            }
            else
            {
                currentPlayer.Call(cashToCall);
            }
            cashToCall = currentPlayer.Bet;
            pot = pot + currentPlayer.Bet - bet;
        }

        private int WaitForUserInput()
        {
            view.playerControlGUI.EnableButtons();

            if (cashToCall > currentPlayer.Bet)
            {

                view.SetMaximumBet(currentPlayer.Cash);
                if (currentPlayer.Cash < cashToCall)
                {
                    view.ChangeButtons(true, currentPlayer.Cash);

                }
                else
                {
                    view.ChangeButtons(true, cashToCall - currentPlayer.Bet);

                }

            }
            else
            {
                view.SetMaximumBet(currentPlayer.Cash);

                view.ChangeButtons(false, 0);

            }

            int choice = 0;
            while (choice == 0)
            {
                // waiting for player
                choice = view.GetPlayerInput();
                Wait(50);
            }

            view.ResetControl();
            view.playerControlGUI.DisableButtons();

            return choice; 

        }

        private void Wait(int milliseconds)
        {
            // https://stackoverflow.com/questions/22158278/wait-some-seconds-without-blocking-ui-execution

            if (milliseconds < 1) return;
            DateTime dateTime = DateTime.Now.AddMilliseconds(milliseconds);
            while (DateTime.Now < dateTime)
            {
                System.Windows.Forms.Application.DoEvents();
            }
        }


        private void DealCards()
        {
            foreach (var player in players)
            {
                player.HoleCards.SetCards(deck.DrawCard(), deck.DrawCard());

            }
            ShowPlayerCards(players[0]);
            ShowPlayerCards(players[1]);
            ShowPlayerCards(players[2]);
            ShowPlayerCards(players[3]);

        }

        private void ShowPlayerCards(Player player)
        {
            view.DisplayPlayerCards(player, player.HoleCards.Card1.Image, player.HoleCards.Card2.Image);

        }

        private void SetUpFirstRound()
        {
            pot = 0;
            AssignDealer(GetNextPlayer(currentDealer)); 
           
            deck = new Deck();
            deck.Shuffle();

            SetBlinds();
            DealCards();
            view.HidePlayerCards();

            foreach (var player in players)
            {
                player.HasFolded = false;
                player.IsPassive = false; 
            }

        }

        private void SetBlinds()
        {
            Player smallBlindPlayer = GetNextPlayer(currentDealer);
            smallBlindPlayer.Raise(smallBlind);

            Player bigBlindPlayer = GetNextPlayer(smallBlindPlayer);

            bigBlindPlayer.Raise(bigBlind);

            cashToCall = bigBlind;
            pot = bigBlind + smallBlind;
            view.UpdatePlayers(players);
            view.UpdatePot(pot);
            currentPlayer = GetNextPlayer(bigBlindPlayer);

        }

        private Player GetNextPlayer(Player player)
        {

            if(players.IndexOf(player) == (players.Count - 1))
            {
                if (players[0].HasFolded || players[0].IsBroke)
                {
                    return GetNextPlayer(players[0]);
                }
                else
                {
                    return players[0];

                }
            }
            else
            {
                
                var nextP =  players[players.IndexOf(player) + 1];
                if (nextP.HasFolded|| nextP.IsBroke)
                {
                    return GetNextPlayer(nextP);
                }
                else
                {
                    return nextP; 
                }

            }


        }
        

       

        public void SetUpGame()
        {
            // Creates players
            players.Add(new Player("You", 0));
            players.Add(new Player("Johnny", 1));
            players.Add(new Player("Steve", 2));
            players.Add(new Player("Bob", 3));

            // Setup bots personalites
            players[0].Ai = null;

            pot = 0;
            activePlayers.AddRange(players); 
            foreach (var player in players)
            {
                player.Cash = startingCash; 
            }

            var v = PointManager.ReadPoints();
            players[0].Cash = v.Item2;
            points = v.Item1; 
            view.SetUpGame(players);
            view.UpdatePlayers(players);

            Random rand = new Random();
            int dealerIndex = rand.Next(0, players.Count); 
            AssignDealer(players[dealerIndex]);

        }

        private void AssignDealer(Player dealer)
        {
            foreach (var player in players)
            {
                player.IsDealer = false; 
            }

            dealer.IsDealer = true;
            currentDealer = dealer; 
            view.DisplayDealer(dealer);

        }


    }
}
