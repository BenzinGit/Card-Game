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
    public partial class PlayerControlBlackJackGUI : UserControl
    {

        private int bet;
        private int choice; 
        public PlayerControlBlackJackGUI()
        {
            InitializeComponent();
            bet = 0;
            choice = 0;
        }

        public int Bet { get => bet; set => bet = value; }
        public int Choice { get => choice; set => choice = value; }

        private void doubleButton_Click(object sender, EventArgs e)
        {
            if (bet != 0)
            {
                choice = 2;
            }
            bet = ((int)numeric.Value);
           
           

        }

        private void slider_Scroll(object sender, EventArgs e)
        {
            numeric.Value = slider.Value;

        }

        private void standButton_Click(object sender, EventArgs e)
        {
            choice = -1; 
        }

        private void hitButton_Click(object sender, EventArgs e)
        {
            choice = 1; 
        }
    }
}
