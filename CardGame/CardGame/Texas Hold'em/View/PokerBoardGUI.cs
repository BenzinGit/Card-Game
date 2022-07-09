using CardGame.Texas_Hold_em.Controller;
using CardGame.Texas_Hold_em.Model;
using CardGame.Texas_Hold_em.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame.View
{
    public partial class TexasHoldem : UserControl
    {


        private Controller controller;
        private List<PlayerGUI> playerList; 
        public TexasHoldem()
        {
            InitializeComponent();

            setUpPlayerGUI();
            controller = new Controller(this);


        }

        

        public void setUpPlayerGUI()
        {

            playerList = new List<PlayerGUI>();

            playerList.Add(playerGUI1);
            playerList.Add(playerGUI2);
            playerList.Add(playerGUI3);
            playerList.Add(playerGUI4);

        }

        public void displayPlayerCards(int player, string card1, string card2)
        {
            playerList[player].setCards(card1, card2);
        
        }

        public void DisplayFlop(string card1, string card2, string card3)
        {
           community.setFlop(card1, card2, card3); 

        }

        public void HidePlayerCards()
        {
            for (int i = 1; i < 4; i++)
            {
                playerList[i].setCards("cardback", "cardback");

            }
        }

       

        public void DisplayTurn(string card)
        {

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

               community.setRiver(card); 
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

        internal void setUpGame(List<Player> players, int startingCash)
        {

            community.setPot(0);
            int i = 0; 
            foreach (var player in playerList)
            {
                player.playerCash.Text = ("$"+startingCash.ToString());
                player.name.Text = players[i].Name;
                i++; 
            }

        }

        internal void DisplayEndHands(List<Player> playersLeft)
        {
            for (int i = 0; i < playersLeft.Count; i++)
            {
                playerList[i].callSign.Visible = true; 
                playerList[i].callSign.Text = playersLeft[i].EndHand.HandName;
            

                playerList[i].betIcon.Visible = false;

            }

        }

        internal void HighlightPlayer(int playerIndex)
        {
            foreach (var player in playerList)
            {
                player.BackColor = Color.Transparent; 

            }

            playerList[playerIndex].BackColor = Color.LimeGreen; 

        }

        internal void DisplayDealer(int playerIndex)
        {
            foreach (var player in playerList)
            {
                player.dealerIcon.Visible = false; 
            }

            playerList[playerIndex].dealerIcon.Visible = true; 

        }

        public void updateBoard()
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

            controller.PlayGame();
        }

        public void setCallSign(string text, int playerIndex)
        {
            playerList[playerIndex].callSign.Text = text; 
        }
    }
}
