using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CardGame
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
           

        }

        private void texasHoldem1_Load(object sender, EventArgs e)
        {
       
        }

        private void texasButton_Click(object sender, EventArgs e)
        {
            texasHoldem1.Visible = true;
            texasButton.Visible = false;
            blackButton.Visible = false;
        }

        private void blackButton_Click(object sender, EventArgs e)
        {
            blackJackBoardGUI1.Visible = true;  
            texasButton.Visible = false;
            blackButton.Visible = false;

        }

        private void blackButton_Click_1(object sender, EventArgs e)
        {

            blackJackBoardGUI1.Visible = true; 
            texasButton.Visible = false;
            blackButton.Visible = false;

        }
    }
}
