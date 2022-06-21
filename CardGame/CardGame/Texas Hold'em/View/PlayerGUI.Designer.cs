namespace CardGame.Texas_Hold_em.View
{
    partial class PlayerGUI
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
            this.name = new System.Windows.Forms.Label();
            this.playerCash = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dealerIcon = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.card2 = new System.Windows.Forms.PictureBox();
            this.card1 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dealerIcon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.card1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // name
            // 
            this.name.AutoSize = true;
            this.name.BackColor = System.Drawing.Color.Transparent;
            this.name.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.name.Location = new System.Drawing.Point(7, 79);
            this.name.Margin = new System.Windows.Forms.Padding(3);
            this.name.Name = "name";
            this.name.Padding = new System.Windows.Forms.Padding(3);
            this.name.Size = new System.Drawing.Size(51, 24);
            this.name.TabIndex = 6;
            this.name.Text = "Pedro";
            // 
            // playerCash
            // 
            this.playerCash.AutoSize = true;
            this.playerCash.BackColor = System.Drawing.Color.Transparent;
            this.playerCash.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playerCash.ForeColor = System.Drawing.Color.Lime;
            this.playerCash.Location = new System.Drawing.Point(3, 104);
            this.playerCash.Margin = new System.Windows.Forms.Padding(3);
            this.playerCash.Name = "playerCash";
            this.playerCash.Padding = new System.Windows.Forms.Padding(3);
            this.playerCash.Size = new System.Drawing.Size(66, 29);
            this.playerCash.TabIndex = 3;
            this.playerCash.Text = "$1000";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(118, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(3);
            this.label1.Size = new System.Drawing.Size(39, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "$50";
            // 
            // dealerIcon
            // 
            this.dealerIcon.BackColor = System.Drawing.Color.Transparent;
            this.dealerIcon.Image = global::CardGame.Properties.Resources.dealer__1_;
            this.dealerIcon.Location = new System.Drawing.Point(12, 0);
            this.dealerIcon.Name = "dealerIcon";
            this.dealerIcon.Size = new System.Drawing.Size(35, 31);
            this.dealerIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.dealerIcon.TabIndex = 10;
            this.dealerIcon.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::CardGame.Properties.Resources.poker_chip__1_;
            this.pictureBox2.Location = new System.Drawing.Point(77, -1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(35, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // card2
            // 
            this.card2.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.card2.Image = global::CardGame.Properties.Resources.cardback;
            this.card2.Location = new System.Drawing.Point(91, 36);
            this.card2.Name = "card2";
            this.card2.Size = new System.Drawing.Size(76, 97);
            this.card2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.card2.TabIndex = 4;
            this.card2.TabStop = false;
            // 
            // card1
            // 
            this.card1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.card1.Image = global::CardGame.Properties.Resources.cardback;
            this.card1.Location = new System.Drawing.Point(77, 36);
            this.card1.Name = "card1";
            this.card1.Size = new System.Drawing.Size(76, 97);
            this.card1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.card1.TabIndex = 7;
            this.card1.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CardGame.Properties.Resources.poker_chip__1_;
            this.pictureBox1.Location = new System.Drawing.Point(9, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(50, 44);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // PlayerGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.dealerIcon);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.card2);
            this.Controls.Add(this.card1);
            this.Controls.Add(this.name);
            this.Controls.Add(this.playerCash);
            this.Controls.Add(this.pictureBox1);
            this.Name = "PlayerGUI";
            this.Size = new System.Drawing.Size(173, 138);
            ((System.ComponentModel.ISupportInitialize)(this.dealerIcon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.card1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label name;
        public System.Windows.Forms.PictureBox card1;
        public System.Windows.Forms.PictureBox card2;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label playerCash;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox dealerIcon;
    }
}
