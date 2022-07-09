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
    public partial class community : UserControl
    {
        public community()
        {
            InitializeComponent();
        }

        public void setPot(int cash)
        {
            pot.Text = ("$"+cash.ToString()); 

        }


        public void RemoveCommunityCards()
        {
            flop1.Image = null;      
            flop2.Image = null;
            flop3.Image = null;
            turn.Image = null;
            river.Image = null; 
        }


        internal void setFlop(string card1, string card2, string card3)
        {

            flop1.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(card1);
            flop2.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(card2);
            flop3.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(card3);


        }

        internal void setTurn(string card)
        {

            turn.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(card);

        }

        internal void setRiver(string card)
        {
            river.Image = (Bitmap)Properties.Resources.ResourceManager.GetObject(card);
        }
    }
}
