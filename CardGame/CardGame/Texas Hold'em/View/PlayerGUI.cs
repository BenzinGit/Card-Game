using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame.Texas_Hold_em.View
{
    public partial class PlayerGUI : UserControl
    {
        private int id;

        public int Id { get => id; set => id = value; }

        public PlayerGUI()
        {
            InitializeComponent();

           
           
        }


   

        public void setCash(int cash)
        {
            playerCash.Text = ("$" + cash.ToString()); 
        }

        public void setBet(int bet)
        {
            playerBet.Text = ("$"+ bet.ToString());
        }

        public void turnCards()
        {
            card1.Image = Properties.Resources.cardback;
            card2.Image = Properties.Resources.cardback;



        }


        public void setCards(string c1, string c2)
        {

            card1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(c1);
            card2.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(c2);

        }


    }
}
