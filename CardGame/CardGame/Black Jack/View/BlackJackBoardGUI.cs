using CardGame.Black_Jack.Controller;
using CardGame.Black_Jack.Model;
using CardGame.Texas_Hold_em.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame.Black_Jack.View
{
    public partial class BlackJackBoardGUI : UserControl
    {
        private BlackJackController controller;
        private List<PictureBox> playerCards; 
        private List<PictureBox> dealerCards;  
        
        public BlackJackBoardGUI()
        {
            InitializeComponent();
            controller = new BlackJackController(this);

            dealerCards = new List<PictureBox>();
            playerCards = new List<PictureBox>();

            dealerCards.Add(dealerCard1);
            dealerCards.Add(dealerCard2);
            dealerCards.Add(dealerCard3);
            dealerCards.Add(dealerCard4);
            dealerCards.Add(dealerCard5);
            dealerCards.Add(dealerCard6);

            playerCards.Add(playerCard1);
            playerCards.Add(playerCard2);
            playerCards.Add(playerCard3);
            playerCards.Add(playerCard4);
            playerCards.Add(playerCard5);
            playerCards.Add(playerCard6);
            playerCards.Add(playerCard7);
            playerCards.Add(playerCard8);

        }

        internal void DisplayDealerValue(int dealer)
        {
            dealerValue.Visible = true;

            dealerValue.Text = dealer.ToString();

        }

        internal void DisplayPlayerValue(int player)
        {
            playerValue.Visible = true; 
            playerValue.Text = player.ToString(); 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            playerControlBlackJackGUI.Visible = true; 
            controller.PlayGame(); 
        }

        internal void HideDealerCard()
        {
            dealerCards[1].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject("cardback");
            dealerCards[1].Visible = true; 
        }

        internal void DisplayCards(List<Card> playerCardsIn, List<Card> dealerCardsin)
        {
            int i = 0; 
            if(playerCardsIn != null)   
            foreach (var card in playerCardsIn)
            {
                playerCards[i].Visible = true; 
                playerCards[i].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(card.Image);
                i++; 
            }
            i = 0; 
            if(dealerCardsin != null)
            foreach (var card in dealerCardsin)
            {
                    dealerCards[i].Visible = true;

                    dealerCards[i].Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(card.Image);
                i++;
            }
        }

        internal int GetPlayerChoice()
        {
            return playerControlBlackJackGUI.Choice; 
        }

        internal void UpdatePlayerBet(Model.Player player)
        {
            chipImage.Visible = true;

            playerBet.Visible = true; 
            playerBet.Text = "$"+ player.Bet.ToString(); 
            playerCash.Text = "$"+ player.Cash.ToString();

        }

        internal void ActivateButtons()
        {
            playerControlBlackJackGUI.standButton.Enabled = true;
            playerControlBlackJackGUI.doubleButton.Text = "Double down"; 
            playerControlBlackJackGUI.hitButton.Enabled = true; 


        }


        internal void ResetView()
        {
            playerControlBlackJackGUI.standButton.Enabled = false;
            playerControlBlackJackGUI.doubleButton.Text = "Bet";
            playerControlBlackJackGUI.doubleButton.Enabled = true;
            messageLabel.Text = ""; 
            playerControlBlackJackGUI.hitButton.Enabled = false;
            playerValue.Visible = false;
            dealerValue.Visible = false; 
            chipImage.Visible = false;  
            playerBet.Visible = false;
            foreach (var card in playerCards)
            {
                card.Visible = false; 
            }

            foreach (var card in dealerCards)
            {
                card.Visible = false;
            }
            HideDealerCard();
            playerControlBlackJackGUI.Choice = 0;
            playerControlBlackJackGUI.Bet = 0; 

        }


        internal void ResetChoice()
        {
            playerControlBlackJackGUI.Choice = 0;  

        }

        internal int GetPlayerBet()
        {
          
           return playerControlBlackJackGUI.Bet;
           
        }

        internal void LockControls()
        {
            playerControlBlackJackGUI.doubleButton.Enabled = false;

            playerControlBlackJackGUI.hitButton.Enabled = false;
            playerControlBlackJackGUI.standButton.Enabled = false;

        }

        internal void ShowMessage(string text)
        { 
            messageLabel.Visible = true; 
            messageLabel.Text = text;   
        }


    }
}
