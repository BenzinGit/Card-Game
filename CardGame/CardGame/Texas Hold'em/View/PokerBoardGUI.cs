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

            startGame();
            controller = new Controller(this);
            controller.setUpGame(); 



        }

        public void startGame()
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

        public void displayFlop(string card1, string card2, string card3)
        {
           community.setFlop(card1, card2, card3); 

        }

       

        public void displayTurn(string card)
        {

              community.setTurn(card); 
        }

        public void displayRiver(string card)
        {

               community.setRiver(card); 
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

        internal void highlightPlayer(int player)
        {
            playerList[player].BackColor = Color.LimeGreen; 

        }

        internal void displayDealer(int playerIndex)
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

        public void displayCardHandCombo(string text)
        {
            playerControlGUI.hand.Text = text; 
        }
    }
}
