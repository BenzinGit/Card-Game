namespace CardGame
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.texasHoldem1 = new CardGame.View.TexasHoldem();
            this.texasButton = new System.Windows.Forms.Button();
            this.blackButton = new System.Windows.Forms.Button();
            this.blackJackBoardGUI1 = new CardGame.Black_Jack.View.BlackJackBoardGUI();
            this.SuspendLayout();
            // 
            // texasHoldem1
            // 
            this.texasHoldem1.BackColor = System.Drawing.Color.DarkGreen;
            this.texasHoldem1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.texasHoldem1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.texasHoldem1.Location = new System.Drawing.Point(0, 0);
            this.texasHoldem1.Name = "texasHoldem1";
            this.texasHoldem1.Size = new System.Drawing.Size(1036, 578);
            this.texasHoldem1.TabIndex = 0;
            this.texasHoldem1.Visible = false;
            // 
            // texasButton
            // 
            this.texasButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.texasButton.Location = new System.Drawing.Point(427, 215);
            this.texasButton.Name = "texasButton";
            this.texasButton.Size = new System.Drawing.Size(177, 47);
            this.texasButton.TabIndex = 1;
            this.texasButton.Text = "Texas Hold\'em";
            this.texasButton.UseVisualStyleBackColor = true;
            this.texasButton.Click += new System.EventHandler(this.texasButton_Click);
            // 
            // blackButton
            // 
            this.blackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.blackButton.Location = new System.Drawing.Point(427, 283);
            this.blackButton.Name = "blackButton";
            this.blackButton.Size = new System.Drawing.Size(177, 47);
            this.blackButton.TabIndex = 2;
            this.blackButton.Text = "Black Jack";
            this.blackButton.UseVisualStyleBackColor = true;
            this.blackButton.Click += new System.EventHandler(this.blackButton_Click);
            // 
            // blackJackBoardGUI1
            // 
            this.blackJackBoardGUI1.BackColor = System.Drawing.Color.DarkGreen;
            this.blackJackBoardGUI1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.blackJackBoardGUI1.Location = new System.Drawing.Point(0, 0);
            this.blackJackBoardGUI1.Name = "blackJackBoardGUI1";
            this.blackJackBoardGUI1.Size = new System.Drawing.Size(1036, 578);
            this.blackJackBoardGUI1.TabIndex = 3;
            this.blackJackBoardGUI1.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(1036, 578);
            this.Controls.Add(this.blackButton);
            this.Controls.Add(this.texasButton);
            this.Controls.Add(this.blackJackBoardGUI1);
            this.Controls.Add(this.texasHoldem1);
            this.Name = "Form1";
            this.Text = "Card Game";
            this.ResumeLayout(false);

        }

        #endregion

        private View.TexasHoldem texasHoldem1;
        private System.Windows.Forms.Button texasButton;
        private System.Windows.Forms.Button blackButton;
        private Black_Jack.View.BlackJackBoardGUI blackJackBoardGUI1;
    }
}

