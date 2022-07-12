using CardGame.View;
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
    public partial class PlayerControlGUI : UserControl
    {
        private int choice;
      //  private TexasHoldem main; 

        public PlayerControlGUI()
        {
            InitializeComponent();
            choice = 0;
           // this.main = main; 
        }


        public int Choice { get => choice; set => choice = value; }

        private void foldButton_Click(object sender, EventArgs e)
        {
            choice = -1; 
        }

        private void checkButton_Click(object sender, EventArgs e)
        {
            choice = 1; 
        }

        private void betButton_Click(object sender, EventArgs e)
        {
            choice = ((int)numeric.Value); 
        }

        public void EnableButtons()
        {
            foldButton.Enabled = true;
            checkButton.Enabled = true;
            betButton.Enabled = true;
        }

        public void DisableButtons()
        {
            foldButton.Enabled = false; 
            checkButton.Enabled = false;
            betButton.Enabled = false;

        }

        private void slider_Scroll(object sender, EventArgs e)
        {
            numeric.Value = slider.Value; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
         //   main.Skip(); 


        }

        private void playButton_Click(object sender, EventArgs e)
        {
          //  main.PlayNormalSpeed()
        }
    }


  
}
