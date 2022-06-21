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
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 578);
            this.Controls.Add(this.texasHoldem1);
            this.Name = "Form1";
            this.Text = "Card Game";
            this.ResumeLayout(false);

        }

        #endregion

        private View.TexasHoldem texasHoldem1;
    }
}

