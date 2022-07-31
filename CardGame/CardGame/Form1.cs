using CardGame.Point_System;
using CardGame.Sound;
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

        private int gameMode = 0;
        private int points; 
        public Form1()
        {
            InitializeComponent();
            var v = PointManager.ReadPoints();

         
            cashLabel.Text = "$" + v.Item2;
            points = v.Item1;
            pointsLabel.Text = v.Item1 + " points";

            if(v.Item2 == 0)
            {
                texasButton.Enabled = false; 
                blackButton.Enabled = false;
                noCash.Visible = true; 
                refillButton.Visible = true;    
            }
            

        }



        private void texasButton_Click(object sender, EventArgs e)
        {
            texasHoldem1.Visible = true;
            texasButton.Visible = false;
            blackButton.Visible = false;
            backButton.Visible = true;
            cashLabel.Visible = false;
            pointsLabel.Visible = false;
            title.Visible = false;
            refillButton.Visible = false;

            gameMode = 1; 
        }



        private void blackButton_Click_1(object sender, EventArgs e)
        {
            blackJackBoardGUI1.Visible = true; 
            texasButton.Visible = false;
            blackButton.Visible = false;
            backButton.Visible = true;
            cashLabel.Visible = false;
            pointsLabel.Visible = false;
            title.Visible = false;
            refillButton.Visible = false;

            gameMode = 2;

        }

        // Restarts program
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to return to main menu?\nUnsaved progress will be lost.", 
                "Return",
                MessageBoxButtons.OKCancel);

            if(result == DialogResult.OK)
            {
                if (gameMode == 1)
                {
                    texasHoldem1.SaveStats(); 
                }
                else if(gameMode == 2)
                {
                    blackJackBoardGUI1.SaveStats();

                }

                Application.Restart();
                Environment.Exit(0);
            }

         

        }

        private void refillButton_Click(object sender, EventArgs e)
        {
            int refillCash = 5000; 
            PointManager.SavePoints(points, refillCash);
            texasButton.Enabled = true;
            blackButton.Enabled = true;
            noCash.Visible = false;
            refillButton.Visible = false;
            cashLabel.Text = "$" + refillCash.ToString();
            SoundManager.PlaySound("cashIn"); 

        }
    }
}
