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
            this.texasButton = new System.Windows.Forms.Button();
            this.blackButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.cashLabel = new System.Windows.Forms.Label();
            this.pointsLabel = new System.Windows.Forms.Label();
            this.noCash = new System.Windows.Forms.Label();
            this.title = new System.Windows.Forms.Label();
            this.refillButton = new System.Windows.Forms.Button();
            this.blackJackBoardGUI1 = new CardGame.Black_Jack.View.BlackJackBoardGUI();
            this.texasHoldem1 = new CardGame.View.TexasHoldem();
            this.SuspendLayout();
            // 
            // texasButton
            // 
            this.texasButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.texasButton.BackColor = System.Drawing.Color.Brown;
            this.texasButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.texasButton.Font = new System.Drawing.Font("Niagara Engraved", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texasButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.texasButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.texasButton.Location = new System.Drawing.Point(404, 243);
            this.texasButton.Name = "texasButton";
            this.texasButton.Size = new System.Drawing.Size(231, 51);
            this.texasButton.TabIndex = 1;
            this.texasButton.Text = "Texas Hold\'em";
            this.texasButton.UseVisualStyleBackColor = false;
            this.texasButton.Click += new System.EventHandler(this.texasButton_Click);
            // 
            // blackButton
            // 
            this.blackButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.blackButton.BackColor = System.Drawing.Color.Gray;
            this.blackButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.blackButton.Font = new System.Drawing.Font("Niagara Engraved", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blackButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.blackButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.blackButton.Location = new System.Drawing.Point(404, 311);
            this.blackButton.Name = "blackButton";
            this.blackButton.Size = new System.Drawing.Size(231, 51);
            this.blackButton.TabIndex = 4;
            this.blackButton.Text = "Black Jack";
            this.blackButton.UseVisualStyleBackColor = false;
            this.blackButton.Click += new System.EventHandler(this.blackButton_Click_1);
            // 
            // backButton
            // 
            this.backButton.BackColor = System.Drawing.Color.Transparent;
            this.backButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.backButton.Font = new System.Drawing.Font("Niagara Engraved", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.backButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.backButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.backButton.Location = new System.Drawing.Point(12, 12);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(105, 34);
            this.backButton.TabIndex = 6;
            this.backButton.Text = "Main Menu";
            this.backButton.UseVisualStyleBackColor = false;
            this.backButton.Visible = false;
            this.backButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // cashLabel
            // 
            this.cashLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cashLabel.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cashLabel.ForeColor = System.Drawing.Color.Gold;
            this.cashLabel.Location = new System.Drawing.Point(5, 527);
            this.cashLabel.Name = "cashLabel";
            this.cashLabel.Size = new System.Drawing.Size(169, 42);
            this.cashLabel.TabIndex = 7;
            this.cashLabel.Text = "$10000";
            this.cashLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pointsLabel
            // 
            this.pointsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pointsLabel.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pointsLabel.ForeColor = System.Drawing.Color.Gold;
            this.pointsLabel.Location = new System.Drawing.Point(743, 527);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(281, 42);
            this.pointsLabel.TabIndex = 8;
            this.pointsLabel.Text = "0 points";
            this.pointsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // noCash
            // 
            this.noCash.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.noCash.AutoSize = true;
            this.noCash.BackColor = System.Drawing.Color.Transparent;
            this.noCash.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noCash.ForeColor = System.Drawing.Color.Red;
            this.noCash.Location = new System.Drawing.Point(466, 215);
            this.noCash.Name = "noCash";
            this.noCash.Size = new System.Drawing.Size(105, 25);
            this.noCash.TabIndex = 9;
            this.noCash.Text = "No cash!";
            this.noCash.Visible = false;
            // 
            // title
            // 
            this.title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.title.Font = new System.Drawing.Font("Playbill", 90F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.ForeColor = System.Drawing.Color.Gold;
            this.title.Location = new System.Drawing.Point(12, 91);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(1012, 124);
            this.title.TabIndex = 10;
            this.title.Text = "Card Game";
            this.title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // refillButton
            // 
            this.refillButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.refillButton.BackColor = System.Drawing.Color.ForestGreen;
            this.refillButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.refillButton.Font = new System.Drawing.Font("Niagara Engraved", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refillButton.ForeColor = System.Drawing.SystemColors.Control;
            this.refillButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.refillButton.Location = new System.Drawing.Point(404, 379);
            this.refillButton.Name = "refillButton";
            this.refillButton.Size = new System.Drawing.Size(231, 51);
            this.refillButton.TabIndex = 11;
            this.refillButton.Text = "Refill $$$";
            this.refillButton.UseVisualStyleBackColor = false;
            this.refillButton.Visible = false;
            this.refillButton.Click += new System.EventHandler(this.refillButton_Click);
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.ClientSize = new System.Drawing.Size(1036, 578);
            this.Controls.Add(this.refillButton);
            this.Controls.Add(this.title);
            this.Controls.Add(this.noCash);
            this.Controls.Add(this.pointsLabel);
            this.Controls.Add(this.cashLabel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.blackButton);
            this.Controls.Add(this.texasButton);
            this.Controls.Add(this.blackJackBoardGUI1);
            this.Controls.Add(this.texasHoldem1);
            this.Name = "Form1";
            this.Text = "Card Game";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private View.TexasHoldem texasHoldem1;
        private System.Windows.Forms.Button texasButton;
        private Black_Jack.View.BlackJackBoardGUI blackJackBoardGUI1;
        private System.Windows.Forms.Button blackButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Label cashLabel;
        private System.Windows.Forms.Label pointsLabel;
        private System.Windows.Forms.Label noCash;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Button refillButton;
    }
}

