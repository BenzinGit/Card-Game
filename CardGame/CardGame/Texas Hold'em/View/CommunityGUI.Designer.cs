namespace CardGame.Texas_Hold_em.View
{
    partial class community
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
            this.pot = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.river = new System.Windows.Forms.PictureBox();
            this.turn = new System.Windows.Forms.PictureBox();
            this.flop3 = new System.Windows.Forms.PictureBox();
            this.flop2 = new System.Windows.Forms.PictureBox();
            this.flop1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.river)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.turn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flop3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flop2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flop1)).BeginInit();
            this.SuspendLayout();
            // 
            // pot
            // 
            this.pot.AutoSize = true;
            this.pot.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pot.ForeColor = System.Drawing.Color.Yellow;
            this.pot.Location = new System.Drawing.Point(3, 59);
            this.pot.Name = "pot";
            this.pot.Size = new System.Drawing.Size(34, 26);
            this.pot.TabIndex = 6;
            this.pot.Text = "$0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CardGame.Properties.Resources.casino_chip;
            this.pictureBox1.Location = new System.Drawing.Point(17, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 39);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // river
            // 
            this.river.Location = new System.Drawing.Point(393, 3);
            this.river.Name = "river";
            this.river.Size = new System.Drawing.Size(74, 93);
            this.river.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.river.TabIndex = 4;
            this.river.TabStop = false;
            // 
            // turn
            // 
            this.turn.Location = new System.Drawing.Point(313, 3);
            this.turn.Name = "turn";
            this.turn.Size = new System.Drawing.Size(74, 93);
            this.turn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.turn.TabIndex = 3;
            this.turn.TabStop = false;
            // 
            // flop3
            // 
            this.flop3.Location = new System.Drawing.Point(233, 3);
            this.flop3.Name = "flop3";
            this.flop3.Size = new System.Drawing.Size(74, 93);
            this.flop3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.flop3.TabIndex = 2;
            this.flop3.TabStop = false;
            // 
            // flop2
            // 
            this.flop2.Location = new System.Drawing.Point(153, 3);
            this.flop2.Name = "flop2";
            this.flop2.Size = new System.Drawing.Size(74, 93);
            this.flop2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.flop2.TabIndex = 1;
            this.flop2.TabStop = false;
            // 
            // flop1
            // 
            this.flop1.Location = new System.Drawing.Point(73, 3);
            this.flop1.Name = "flop1";
            this.flop1.Size = new System.Drawing.Size(74, 93);
            this.flop1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.flop1.TabIndex = 0;
            this.flop1.TabStop = false;
            // 
            // community
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pot);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.river);
            this.Controls.Add(this.turn);
            this.Controls.Add(this.flop3);
            this.Controls.Add(this.flop2);
            this.Controls.Add(this.flop1);
            this.Name = "community";
            this.Size = new System.Drawing.Size(476, 103);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.river)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.turn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flop3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flop2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flop1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox flop1;
        private System.Windows.Forms.PictureBox flop2;
        private System.Windows.Forms.PictureBox flop3;
        private System.Windows.Forms.PictureBox turn;
        private System.Windows.Forms.PictureBox river;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label pot;
    }
}
