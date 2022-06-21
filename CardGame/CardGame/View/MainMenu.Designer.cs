namespace CardGame
{
    partial class MainMenu
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
            this.texasButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // texasButton
            // 
            this.texasButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.texasButton.Location = new System.Drawing.Point(193, 182);
            this.texasButton.Name = "texasButton";
            this.texasButton.Size = new System.Drawing.Size(177, 47);
            this.texasButton.TabIndex = 0;
            this.texasButton.Text = "Texas Hold\'em";
            this.texasButton.UseVisualStyleBackColor = true;
            this.texasButton.Click += new System.EventHandler(this.texasButton_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGreen;
            this.Controls.Add(this.texasButton);
            this.Name = "MainMenu";
            this.Size = new System.Drawing.Size(582, 417);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button texasButton;
    }
}
