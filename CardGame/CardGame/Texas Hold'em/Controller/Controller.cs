using CardGame.Texas_Hold_em.Model;
using CardGame.View;
using System;
using System.Collections.Generic;

namespace CardGame.Texas_Hold_em.Controller
{
    internal class Controller
    {
        private int startingCash = 5000;
        private int bigBlind = 50; 
        private int smallBlind = 25;
        private int cashToCall = 0;
      
        private int waitTime = 1000;
        private int waitTimeEnd = 10000;

        private Deck deck; 
        private List<Player> players;
        private List<Player> activePlayers;

        private SharedCards sharedCards;
        private Pot pot; 
        private TexasHoldem view;


        public Controller(TexasHoldem view)
        {
            this.view = view;
         
            players = new List<Player>();
            activePlayers = new List<Player>();

            sharedCards =  new SharedCards();
            pot = new Pot(); 
        }

        public void PlayGame()
        {
            SetUpGame();
            

            while (true)
            {
                int startingPlayer = SetUpFirstRound();

                // remove
                showAllPlayerCards();

                // Preflop
                PlayRound(startingPlayer);
                Wait(waitTime);

                // Flop
                if (activePlayers.Count > 1)
                {
                    startingPlayer = GetNextPlayer(CurrentDealer());
                    PrepareNextRound();
                    DrawFlop();
                    PlayRound(startingPlayer);
                    Wait(waitTime);
                }
                // Turn

                if (activePlayers.Count > 1)
                {
                    PrepareNextRound();
                    DrawTurn();
                    PlayRound(startingPlayer);
                    Wait(waitTime);
                }

                if (activePlayers.Count > 1)
                {

                    // River
                    PrepareNextRound();
                    DrawRiver();
                    PlayRound(startingPlayer);
                    showAllPlayerCards();
                }

               
                var winners = DecideWinner();
                view.HighlightWinners(winners);
                AwardPot(winners);


                view.UpdateBoard();
                Wait(waitTimeEnd);
                KickBrokePlayers();
                ResetRound();
            }

        }

        private void AwardPot(List<Player> winners)
        {
            int winPotShare = pot.pot / winners.Count;

            foreach (var player in winners)
            {
                player.Cash = player.Cash + winPotShare;
            }

        }

        private void KickBrokePlayers()
        {
            foreach (var player in players)
            {
                if (player.Cash <= 0){
                    player.IsBroke = true; 
                }
            }
        }

        private void ResetRound()
        {
            Console.WriteLine("players count: " + players.Count);
            foreach (var player in players)
            {
                player.Bet = 0;
                player.HasFolded = false;
                player.IsPassive = false;

                activePlayers.Clear();
                Console.WriteLine(activePlayers.Count + " is here should be 0");

                if (player.Cash > 0)
                {
                    Console.WriteLine("adding: " + player.Name);
                    activePlayers.Add(player);
                }
               
                Console.WriteLine(activePlayers.Count + " is here should be 4");
            }
            pot.pot = 0;

            sharedCards.RemoveCards();

            view.ResetRound();
        //    view.HidePlayerCards();


        }
        private List<Player> DecideWinner()
        {
           
            var winners = CardEvaluator.DecideWinner(players, sharedCards.GetCards());
            view.DisplayEndHands(players); 
            return winners; 
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

        private void SetUpGame()
        {
            players.Add(new Player("You", 0));
            players.Add(new Player("Johnny", 1));
            players.Add(new Player("Barry", 2));
            players.Add(new Player("Jericho", 3));
            players[0].Ai = null;

            activePlayers.AddRange(players); 
            // Assigning random dealer for game
            Random rand = new Random();
            AssignDealer(rand.Next(0, players.Count));

            foreach (var player in players)
            {
                player.Cash = startingCash; 
            }

            // Setting up view
          //  view.SetUpGame(players);


        }


        private void PlayRound(int startingPlayer)
        {
            
            Player currentPlayer = players[startingPlayer];
            Boolean allPassivePlayers = false;


            while (!allPassivePlayers)
            {
                if (currentPlayer.HasFolded || currentPlayer.IsBroke)
                {
                    currentPlayer = players[GetNextPlayer(players.IndexOf(currentPlayer))]; 
                }


           //     view.HighlightPlayer(players.IndexOf(currentPlayer));

                int choice; 
                
                // Bot players
                if (currentPlayer.Ai != null)
                {
                    Wait(waitTime);
                    choice = currentPlayer.MakeDecision(cashToCall, pot.pot, bigBlind, players, sharedCards.GetCards());

                }

                // Human player
                else
                {
                    view.playerControlGUI.EnableButtons();

                    if(cashToCall > currentPlayer.Bet)
                    {
                        
                        view.SetMaximumBet(currentPlayer.Cash);
                        if(currentPlayer.Cash < cashToCall)
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

                    choice = 0; 
                    while(choice == 0)
                    {
                        // waiting for player
                        choice = view.GetPlayerInput();
                        Wait(50); 
                    }

                    view.ResetControl();
                    view.playerControlGUI.DisableButtons(); 
                }


                // Check / call
                if (choice == 1)
                {
                    if(cashToCall == currentPlayer.Bet)
                    {
                        view.SetCallSign("Check", players.IndexOf(currentPlayer));

                    }
                    else
                    {
                        view.SetCallSign("Call", players.IndexOf(currentPlayer));

                    }

                    int b = currentPlayer.Bet; 
                    if(currentPlayer.Cash < cashToCall)
                    {
                        currentPlayer.Call(currentPlayer.Cash);
                    }
                    else
                    {
                        currentPlayer.Call(cashToCall);
                    }
                    cashToCall = currentPlayer.Bet;
                    pot.pot = pot.pot + currentPlayer.Bet - b;

                }
                
              
                // Fold
                else if (choice == -1)
                {
                    currentPlayer.Fold();
                    view.SetCallSign("Fold", players.IndexOf(currentPlayer));
                    activePlayers.Remove(currentPlayer);    

                }
               
                // Bet / Raise
                else
                {
                    int b = currentPlayer.Bet;

                    if (currentPlayer.Cash < cashToCall)
                    {
                        currentPlayer.Raise(currentPlayer.Cash);
                    }
                    else
                    {
                        currentPlayer.Raise(choice);
                    }


                    cashToCall = currentPlayer.Bet;
                    pot.pot = pot.pot + currentPlayer.Bet - b; 

                    view.SetCallSign("Raise", players.IndexOf(currentPlayer));

                    foreach (var player in players)
                    {
                        if (!player.HasFolded || !player.IsBroke)
                        {
                            player.IsPassive = false;

                        }
                    }
                    currentPlayer.IsPassive = true; 

                }

                

                if (currentPlayer.Cash == 0)
                {
                    currentPlayer.IsPassive = true; 
                }



                view.UpdateBoard();

                if (currentPlayer.Ai != null)
                    Wait(waitTime);




                // Changing players
                currentPlayer = players[(GetNextPlayer(players.IndexOf(currentPlayer)))];
              
                allPassivePlayers = true;  
                foreach (var player in players)
                {
                    if (!player.IsPassive)
                    {
                        allPassivePlayers = false; 
                    }
                }

                Console.WriteLine("Active players: " + activePlayers.Count);

                if (activePlayers.Count < 1)
                {
                    allPassivePlayers = true;
                }
            }

           
        }

       

        public void SetWaitTime(int time)
        {
            waitTime = time;    
        }


        // https://stackoverflow.com/questions/22158278/wait-some-seconds-without-blocking-ui-execution
        private void Wait(int seconds)
        {
            if (seconds < 1) return;
            DateTime dateTime = DateTime.Now.AddMilliseconds(seconds); 
            while (DateTime.Now < dateTime)
            {
                System.Windows.Forms.Application.DoEvents();
            }
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


        private void DrawCustomCommunityCards(Card flop1, Card flop2, Card flop3, Card turn, Card river)
        {
            List<Card> flopCards = new List<Card>();
            flopCards.Add(flop1);
            flopCards.Add(flop2);
            flopCards.Add(flop3);

            sharedCards.SetFlop(flopCards);
            view.DisplayFlop(flopCards[0].Image, flopCards[1].Image, flopCards[2].Image);

            sharedCards.SetTurn(turn);
            view.DisplayTurn(turn.Image);

            sharedCards.SetRiver(river);
            view.displayRiver(river.Image);

        }

        private void DealCustomCards(int playerIndex, Card card1, Card card2)
        {
            players[playerIndex].HoleCards.SetCards(card1, card2);
            showPlayerCards(playerIndex);


        }


        private int SetUpFirstRound()
        {
            assignNextDealer();
            deck = new Deck(); 
            deck.Shuffle();
            DealCards();
            int bigBlindIndex = SetBlinds();
            GetTableBets(); 
            view.UpdateBoard();
            showPlayerCards(0);
                      
            return GetNextPlayer(bigBlindIndex);  
        }



        private int GetNextPlayer(int playerIndex)
        {
            int nextPlayerIndex = playerIndex + 1; 
            if (nextPlayerIndex >= players.Count || players[nextPlayerIndex].IsBroke)
            {
                if (players[0].HasFolded)
                {
                    return GetNextPlayer(0);
                }
                else
                {
                    return 0;

                }

            }
            else
            {
                if (players[nextPlayerIndex].HasFolded || players[nextPlayerIndex].IsBroke)
                {
                    return GetNextPlayer(nextPlayerIndex);
                }
                else
                {
                    return nextPlayerIndex;

                }
            }
        }
        

        private void GetTableBets()
        {
            foreach (var player in players)
            {
                pot.pot += player.Bet; 
            }

        }

        private int SetBlinds()
        {
            int i = CurrentDealer();

            int smallBlindIndex = i + 1;
            int bigBlindIndex = i + 2;

            if (smallBlindIndex >= players.Count)
            {
                smallBlindIndex = 0;

            }

            if (bigBlindIndex >= players.Count + 1)
            {
                bigBlindIndex = 1;
            }

            else if (bigBlindIndex >= players.Count)
            {
                bigBlindIndex = 0;  
            }


            players[smallBlindIndex].Raise(smallBlind);
            players[bigBlindIndex].Raise(bigBlind);
            cashToCall = bigBlind; 
            return bigBlindIndex; 

        }

        public int getPlayerCash(int i)
        {

            return players[i].Cash;

        }

        public int getPlayerBet(int i)
        {
            return players[i].Bet; 

        }


        public int getPot()
        {
            return pot.pot; 

        }


        private void assignNextDealer()
        {
            int i = CurrentDealer(); 


            if (i+1 == players.Count)
            {
                AssignDealer(0);
            }
            else
            {
                AssignDealer(i + 1);
            }

        }

        private int CurrentDealer()
        {
            int i = 0; 
            foreach (var player in players)
            {
                if (player.IsDealer)
                {
                    break;
                }
                i++;
            }
            return i; 

        }

        private void DealCards()
        {
            foreach (var player in players)
            {
                player.HoleCards.SetCards(deck.DrawCard(), deck.DrawCard());     
                    

            }
        }

 

        private void AssignDealer(int playerIndex)
        {

      
        }

        private void showPlayerCards(int playerIndex)
        {

      //      view.DisplayPlayerCards(playerIndex, players[playerIndex].HoleCards.Card1.Image, players[playerIndex].HoleCards.Card2.Image);

        }

        private void HideOtherPlayerCards()
        {
            view.HidePlayerCards(); 

        }

        private void showAllPlayerCards()
        {

            for(int i = 0; i < players.Count; i++)
            {
              //  view.DisplayPlayerCards(i, players[i].HoleCards.Card1.Image, players[i].HoleCards.Card2.Image);

            }


        }

    }
}
