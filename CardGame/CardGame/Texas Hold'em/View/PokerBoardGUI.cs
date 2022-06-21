using CardGame.Texas_Hold_em.Controller;
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









    }
}
