using CardGame.Black_Jack.Model;
using CardGame.Black_Jack.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame.Black_Jack.Controller
{
    internal class BlackJackController
    {

        private Player dealer; 
        private Player player;
        private Deck deck;
        private BlackJackBoardGUI view;


        private int waitTime = 1000; 
        public BlackJackController(BlackJackBoardGUI view)
        {
            this.view = view; 
        }
        

        
        
        
        private void DealCards()
        {
           
            player.Cards.Add(deck.DrawCard());
            dealer.Cards.Add(deck.DrawCard());
            player.Cards.Add(deck.DrawCard());

        }



        private void SetUpGame()
        {
            dealer = new Player();
            player = new Player();

            player.Cash = 5000;
            view.UpdatePlayerBet(player); 
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

        private void GetPlayerBet()
        {
            bool hasBet = false;
            int choice = 0; 
            while(hasBet == false)
            {
                choice = view.GetPlayerBet();
                Wait(50);
                if(choice >= 50)
                {

                    hasBet = true;  
                }
            }

            player.PlaceBet(choice); 
        }

        private void UpdateGUI()
        {
            view.DisplayCards(player.Cards, dealer.Cards);
            view.DisplayPlayerValue(player.CardValue);
            view.DisplayDealerValue(CardAdapter.GetValue(dealer.Cards[0]));


            view.HideDealerCard();
            view.ActivateButtons();


        }

        private int GetPlayerChoice()
        {
            int choice = 0;
            while (choice == 0)
            {
                choice = view.GetPlayerChoice(); 
                Wait(50);
              
            }

            view.ResetChoice(); 
            return choice; 

        }

        private void DealCardDealer()
        {
            dealer.AddCard(deck.DrawCard());
            view.DisplayCards(null, dealer.Cards);
            view.DisplayDealerValue(dealer.CardValue);
        }

        private void DealCardPlayer()
        {

            player.AddCard(deck.DrawCard());
            view.DisplayCards(player.Cards, null);
            view.DisplayPlayerValue(player.CardValue); 

        }


        private int DealerPlay()
        {
            while (dealer.CardValue <= 16)
            {
                Wait(waitTime);

                DealCardDealer();
            }

            return dealer.CardValue; 
        }


        private int PlayerPlay()
        {
            if(player.CardValue == 21)
            {
                return player.CardValue; 
            }
            int choice = GetPlayerChoice();

            if (choice == 1)
            {
                while (choice == 1 && player.CardValue < 21)
                {
                    DealCardPlayer();
                    if (player.CardValue >= 21)
                    {
                        return player.CardValue;
                    }
                    choice = GetPlayerChoice();

                   
                }
            }

            // Stand
            if (choice == -1)
            {
                return player.CardValue;

            }
            else 
            {
                player.DoubleDown(); 
                DealCardPlayer();
                view.UpdatePlayerBet(player);

                return player.CardValue;

            }

        }

        private void ResetRound()
        {

            player.Cards.Clear();
            dealer.Cards.Clear();
            deck = new Deck();

            view.ResetView(); 
        }

        public void PlayGame()
        {
            SetUpGame();

            while (true)
            {
                ResetRound(); 
                GetPlayerBet();
                view.UpdatePlayerBet(player); 
                deck.Shuffle();
               
                DealCards();
                player.SetValue();
                dealer.SetValue();
                UpdateGUI();

                int playerCardValue = PlayerPlay();
                if(playerCardValue > 21)
                {
                    view.LockControls();
                    view.ShowMessage("Bust!");
                    view.messageLabel.ForeColor = Color.OrangeRed;

                    player.Lose();

                }
                else
                {

                    view.LockControls();
                    DealerPlay(); 
                    if(dealer.CardValue > 21)
                    {
                        view.ShowMessage("Dealer bust!");
                        view.messageLabel.ForeColor = Color.Lime;
                        player.Win();

                    }
                    else if (dealer.CardValue > player.CardValue)
                    {
                        view.ShowMessage("Dealer wins!");
                        view.messageLabel.ForeColor = Color.OrangeRed;

                        player.Lose(); 
                    }
                    else if(dealer.CardValue < player.CardValue)
                    {
                        view.messageLabel.ForeColor = Color.Lime;

                        view.ShowMessage("Player wins!");
                        player.Win(); 

                    }
                    else
                    {

                        view.ShowMessage("Tie!");
                        player.Tie();
                        view.messageLabel.ForeColor = Color.Gold;


                    }
                }
                Wait(waitTime * 2); 
                view.UpdatePlayerBet(player);
                Wait(waitTime * 2);

                 
            }

        }












    }


   
}
