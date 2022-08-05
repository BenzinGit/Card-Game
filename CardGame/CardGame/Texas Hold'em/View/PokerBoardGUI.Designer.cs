namespace CardGame.View
{
    partial class TexasHoldem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.startButton = new System.Windows.Forms.Button();
            this.playerControlGUI = new CardGame.Texas_Hold_em.View.PlayerControlGUI();
            this.community = new CardGame.Texas_Hold_em.View.community();
            this.playerGUI4 = new CardGame.Texas_Hold_em.View.PlayerGUI();
            this.playerGUI3 = new CardGame.Texas_Hold_em.View.PlayerGUI();
            this.playerGUI2 = new CardGame.Texas_Hold_em.View.PlayerGUI();
            this.playerGUI1 = new CardGame.Texas_Hold_em.View.PlayerGUI();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.startButton.Font = new System.Drawing.Font("Niagara Engraved", 21.75F);
            this.startButton.Location = new System.Drawing.Point(471, 254);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(182, 46);
            this.startButton.TabIndex = 8;
            this.startButton.Text = "Start Game";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // playerControlGUI
            // 
            this.playerControlGUI.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.playerControlGUI.BackColor = System.Drawing.SystemColors.Control;
            this.playerControlGUI.Choice = 0;
            this.playerControlGUI.Location = new System.Drawing.Point(0, 557);
            this.playerControlGUI.Name = "playerControlGUI";
            this.playerControlGUI.Size = new System.Drawing.Size(1096, 74);
            this.playerControlGUI.TabIndex = 9;
            // 
            // community
            // 
            this.community.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.community.Location = new System.Drawing.Point(302, 216);
            this.community.Name = "community";
            this.community.Size = new System.Drawing.Size(495, 127);
            this.community.TabIndex = 4;
            // 
            // playerGUI4
            // 
            this.playerGUI4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.playerGUI4.BackColor = System.Drawing.Color.Transparent;
            this.playerGUI4.Id = 0;
            this.playerGUI4.Location = new System.Drawing.Point(923, 254);
            this.playerGUI4.Name = "playerGUI4";
            this.playerGUI4.Size = new System.Drawing.Size(173, 157);
            this.playerGUI4.TabIndex = 3;
            // 
            // playerGUI3
            // 
            this.playerGUI3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.playerGUI3.BackColor = System.Drawing.Color.Transparent;
            this.playerGUI3.Id = 0;
            this.playerGUI3.Location = new System.Drawing.Point(439, 3);
            this.playerGUI3.Name = "playerGUI3";
            this.playerGUI3.Size = new System.Drawing.Size(173, 164);
            this.playerGUI3.TabIndex = 2;
            // 
            // playerGUI2
            // 
            this.playerGUI2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.playerGUI2.BackColor = System.Drawing.Color.Transparent;
            this.playerGUI2.Id = 0;
            this.playerGUI2.Location = new System.Drawing.Point(19, 243);
            this.playerGUI2.Name = "playerGUI2";
            this.playerGUI2.Size = new System.Drawing.Size(173, 168);
            this.playerGUI2.TabIndex = 1;
            // 
            // playerGUI1
            // 
            this.playerGUI1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.playerGUI1.BackColor = System.Drawing.Color.Transparent;
            this.playerGUI1.Id = 0;
            this.playerGUI1.Location = new System.Drawing.Point(430, 387);
            this.playerGUI1.Name = "playerGUI1";
            this.playerGUI1.Size = new System.Drawing.Size(173, 169);
            this.playerGUI1.TabIndex = 0;
            // 
            // TexasHoldem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.Controls.Add(this.playerControlGUI);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.community);
            this.Controls.Add(this.playerGUI4);
            this.Controls.Add(this.playerGUI3);
            this.Controls.Add(this.playerGUI2);
            this.Controls.Add(this.playerGUI1);
            this.Name = "TexasHoldem";
            this.Size = new System.Drawing.Size(1099, 634);
            this.ResumeLayout(false);

        }

        #endregion
        private Texas_Hold_em.View.PlayerGUI player1;
        private Texas_Hold_em.View.PlayerGUI player2;
        private Texas_Hold_em.View.PlayerGUI player3;
        private Texas_Hold_em.View.PlayerGUI player4;
        private Texas_Hold_em.View.community community_Cards_GUI1;
        private Texas_Hold_em.View.community community;
        private System.Windows.Forms.Button startButton;
        public Texas_Hold_em.View.PlayerGUI playerGUI1;
        public Texas_Hold_em.View.PlayerGUI playerGUI2;
        public Texas_Hold_em.View.PlayerGUI playerGUI3;
        public Texas_Hold_em.View.PlayerGUI playerGUI4;
        public Texas_Hold_em.View.PlayerControlGUI playerControlGUI;
    }
}
