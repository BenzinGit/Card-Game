﻿namespace CardGame.View
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
            this.log = new System.Windows.Forms.RichTextBox();
            this.playerControlGUI1 = new CardGame.Texas_Hold_em.View.PlayerControlGUI();
            this.community = new CardGame.Texas_Hold_em.View.community();
            this.playerGUI4 = new CardGame.Texas_Hold_em.View.PlayerGUI();
            this.playerGUI3 = new CardGame.Texas_Hold_em.View.PlayerGUI();
            this.playerGUI2 = new CardGame.Texas_Hold_em.View.PlayerGUI();
            this.playerGUI1 = new CardGame.Texas_Hold_em.View.PlayerGUI();
            this.SuspendLayout();
            // 
            // log
            // 
            this.log.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.log.Location = new System.Drawing.Point(912, 564);
            this.log.Name = "log";
            this.log.Size = new System.Drawing.Size(187, 67);
            this.log.TabIndex = 6;
            this.log.Text = "";
            // 
            // playerControlGUI1
            // 
            this.playerControlGUI1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.playerControlGUI1.BackColor = System.Drawing.SystemColors.Control;
            this.playerControlGUI1.Location = new System.Drawing.Point(0, 564);
            this.playerControlGUI1.Name = "playerControlGUI1";
            this.playerControlGUI1.Size = new System.Drawing.Size(1099, 67);
            this.playerControlGUI1.TabIndex = 5;
            // 
            // community
            // 
            this.community.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.community.Location = new System.Drawing.Point(302, 254);
            this.community.Name = "community";
            this.community.Size = new System.Drawing.Size(495, 127);
            this.community.TabIndex = 4;
            // 
            // playerGUI4
            // 
            this.playerGUI4.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.playerGUI4.BackColor = System.Drawing.Color.Transparent;
            this.playerGUI4.Location = new System.Drawing.Point(923, 254);
            this.playerGUI4.Name = "playerGUI4";
            this.playerGUI4.Size = new System.Drawing.Size(173, 138);
            this.playerGUI4.TabIndex = 3;
            // 
            // playerGUI3
            // 
            this.playerGUI3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.playerGUI3.BackColor = System.Drawing.Color.Transparent;
            this.playerGUI3.Location = new System.Drawing.Point(439, 3);
            this.playerGUI3.Name = "playerGUI3";
            this.playerGUI3.Size = new System.Drawing.Size(173, 138);
            this.playerGUI3.TabIndex = 2;
            // 
            // playerGUI2
            // 
            this.playerGUI2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.playerGUI2.BackColor = System.Drawing.Color.Transparent;
            this.playerGUI2.Location = new System.Drawing.Point(19, 243);
            this.playerGUI2.Name = "playerGUI2";
            this.playerGUI2.Size = new System.Drawing.Size(173, 138);
            this.playerGUI2.TabIndex = 1;
            // 
            // playerGUI1
            // 
            this.playerGUI1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.playerGUI1.BackColor = System.Drawing.Color.Transparent;
            this.playerGUI1.Location = new System.Drawing.Point(426, 424);
            this.playerGUI1.Name = "playerGUI1";
            this.playerGUI1.Size = new System.Drawing.Size(173, 138);
            this.playerGUI1.TabIndex = 0;
            // 
            // TexasHoldem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.Controls.Add(this.log);
            this.Controls.Add(this.playerControlGUI1);
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
        private Texas_Hold_em.View.PlayerControlGUI playerControl;
        private Texas_Hold_em.View.community community_Cards_GUI1;
        private Texas_Hold_em.View.PlayerGUI playerGUI1;
        private Texas_Hold_em.View.PlayerGUI playerGUI2;
        private Texas_Hold_em.View.PlayerGUI playerGUI3;
        private Texas_Hold_em.View.PlayerGUI playerGUI4;
        private Texas_Hold_em.View.community community;
        private Texas_Hold_em.View.PlayerControlGUI playerControlGUI1;
        private System.Windows.Forms.RichTextBox log;
    }
}
