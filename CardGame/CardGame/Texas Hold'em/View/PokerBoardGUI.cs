using CardGame.Black_Jack.Controller;
using CardGame.Texas_Hold_em.Controller;
using CardGame.Texas_Hold_em.Model;
using CardGame.Texas_Hold_em.Testing;
using CardGame.Texas_Hold_em.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame.View
{
    public partial class TexasHoldem : UserControl
    {

        private Controller controller;

        private TexasHoldemController texasController;
        private List<PlayerGUI> playerList; 
        
        public TexasHoldem()
        {
            InitializeComponent();

            SetUpPlayerGUI();
           // controller = new Controller(this);
        //    TestingController Tcontroller = new TestingController();
        //     Tcontroller.RunTest(); 
            texasController = new TexasHoldemController(this);
        }

        

        public void SetUpPlayerGUI()
        {

            playerList = new List<PlayerGUI>();

            playerList.Add(playerGUI1);
            playerList.Add(playerGUI2);
            playerList.Add(playerGUI3);
            playerList.Add(playerGUI4);

        }

        internal void DisplayPlayerCards(Player playerIn, string card1, string card2)
        {
            foreach (var player in playerList)
            {
                     if(player.Id == playerIn.Id)
                    {
                          player.setCards(card1, card2);

                    }
            }
        
        }

        public void DisplayFlop(string card1, string card2, string card3)
        {
            PlaySound("cardflip"); 
           community.setFlop(card1, card2, card3); 

        }

        public void HidePlayerCards()
        {
            for (int i = 1; i < 4; i++)
            {
                playerList[i].setCards("cardback", "cardback");

            }
        }
        public void UpdatePot(int pot)
        {

            community.setPot(pot); 
        }
       

        public void DisplayTurn(string card)
        {
            PlaySound("cardflip");

            community.setTurn(card); 
        }

        internal void RemoveBets()
        {
            foreach (var players in playerList)
            {
                players.setBet(0);  
            }
        }

       

        public void displayRiver(string card)
        {
            PlaySound("cardflip");

            community.setRiver(card); 
        }

        internal void HighlightWinners(List<Player> winners)
        {
            foreach (var player in playerList)
            {
                player.BackColor = Color.Transparent;

            }

            foreach (var winner in winners)
            {
                playerList[winner.Id].BackColor = Color.Orange;

            }
            PlaySound("win"); 
        }

        internal void HighlightWinner(int winnnerIndex)
        {
            foreach (var player in playerList)
            {
                player.BackColor = Color.Transparent;

            }

            playerList[winnnerIndex].BackColor = Color.Orange;
        }

        internal void ResetRound()
        {
            foreach (var player in playerList)
            {
                player.BackColor = Color.Transparent;
                player.betIcon.Visible = true;
                player.callSign.Text = ""; 
            }
            community.setPot(0);
            community.RemoveCommunityCards(); 
           

        }

        internal void SetUpGame(List<Player> players)
        {
            int i = 0;
            community.setPot(0);

            foreach (var player in playerList)
            {
                player.name.Text = players[i].Name;
                player.Id = players[i].Id;

                i++;
            }

        }


        internal void DisplayEndHands(List<Player> players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                if (!players[i].HasFolded)
                {
                    playerList[i].callSign.Visible = true;
                    playerList[i].callSign.Text = players[i].EndHand.HandName;
                    playerList[i].betIcon.Visible = false;
                }
            }
        }

        internal void HighlightPlayer(Player playerIn)
        {
            foreach (var player in playerList)
            {

                player.BackColor = Color.Transparent; 
                if(player.Id == playerIn.Id)
                {
                    player.BackColor = Color.Green;
                }
            }




        }

        internal void DisplayDealer(Player dealer)
        {
            foreach (var player in playerList)
            {
                player.dealerIcon.Visible = false; 

            }


            playerList[dealer.Id].dealerIcon.Visible = true; 

        }

        internal void UpdatePlayers(List<Player> players)
        {
            int i = 0;
            foreach (var player in players)
            {
                if(player.Id == playerList[i].Id)
                {
                    playerList[i].setCash(player.Cash);
                    playerList[i].setBet(player.Bet);

                }
                i++; 
            }


        }


        public void UpdateBoard()
        {
            int i = 0;
            foreach (var player in playerList)
            {
                playerList[i].setCash(controller.getPlayerCash(i));
                playerList[i].setBet(controller.getPlayerBet(i));

                i++; 


            }

            community.setPot(controller.getPot()); 


        }

        internal void ChangeButtons(Boolean b, int cashToCall)
        {
            if (b)
            {
                playerControlGUI.checkButton.Text = ("Call (" + cashToCall+")");
                playerControlGUI.betButton.Text = "Raise";    
            }
            else
            {
                playerControlGUI.checkButton.Text = "Check";
                playerControlGUI.betButton.Text = "Bet";
            }
        }

        internal void ResetControl()
        {
            playerControlGUI.Choice = 0;
        }

        internal void SetMaximumBet(int cash)
        {
            playerControlGUI.slider.Maximum = cash;
            playerControlGUI.numeric.Maximum = cash; 
        }

        public int GetPlayerInput()
        {
            return playerControlGUI.Choice; 

        }

        public void displayCardHandCombo(string text)
        {
    //        playerControlGUI.hand.Text = text; 
        }

        private void startButton_Click(object sender, EventArgs e)
        {
          
            startButton.Visible = false;
            texasController.PlayGame();
          
        }

        private void PlaySound(string soundEffect)
        {
            SoundPlayer simpleSound = new SoundPlayer("../../Sounds/"+soundEffect+".wav");
            simpleSound.Play();

        }

        public void SetCallSign(string text, int playerIndex)
        {
            playerList[playerIndex].callSign.Text = text; 

          
            if(text == "Raise")
            {
                PlaySound("chipdrop"); 
            }
        }

        internal void FoldPlayer(Player currentPlayer)
        {
            foreach (var player in playerList)
            {
                if(player.Id == currentPlayer.Id)
                {
                    player.BackColor = Color.Gray; 
                }
            }
        }

        public void Skip()
        {

            controller.SetWaitTime(0); 
        }

        internal void PlayNormalSpeed()
        {
            controller.SetWaitTime(1000);

        }
    }
}
