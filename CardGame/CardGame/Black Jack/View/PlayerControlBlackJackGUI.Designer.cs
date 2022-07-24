namespace CardGame.Black_Jack.View
{
    partial class PlayerControlBlackJackGUI
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
            this.doubleButton = new System.Windows.Forms.Button();
            this.hitButton = new System.Windows.Forms.Button();
            this.standButton = new System.Windows.Forms.Button();
            this.numeric = new System.Windows.Forms.NumericUpDown();
            this.slider = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.numeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).BeginInit();
            this.SuspendLayout();
            // 
            // doubleButton
            // 
            this.doubleButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.doubleButton.ForeColor = System.Drawing.SystemColors.Control;
            this.doubleButton.Location = new System.Drawing.Point(335, 28);
            this.doubleButton.Name = "doubleButton";
            this.doubleButton.Size = new System.Drawing.Size(100, 39);
            this.doubleButton.TabIndex = 11;
            this.doubleButton.Text = "Bet";
            this.doubleButton.UseVisualStyleBackColor = false;
            this.doubleButton.Click += new System.EventHandler(this.doubleButton_Click);
            // 
            // hitButton
            // 
            this.hitButton.Enabled = false;
            this.hitButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.hitButton.Location = new System.Drawing.Point(229, 28);
            this.hitButton.Name = "hitButton";
            this.hitButton.Size = new System.Drawing.Size(100, 39);
            this.hitButton.TabIndex = 12;
            this.hitButton.Text = "Hit";
            this.hitButton.UseVisualStyleBackColor = true;
            this.hitButton.Click += new System.EventHandler(this.hitButton_Click);
            // 
            // standButton
            // 
            this.standButton.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.standButton.Enabled = false;
            this.standButton.Location = new System.Drawing.Point(123, 28);
            this.standButton.Name = "standButton";
            this.standButton.Size = new System.Drawing.Size(100, 39);
            this.standButton.TabIndex = 13;
            this.standButton.Text = "Stand";
            this.standButton.UseVisualStyleBackColor = false;
            this.standButton.Click += new System.EventHandler(this.standButton_Click);
            // 
            // numeric
            // 
            this.numeric.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numeric.Location = new System.Drawing.Point(441, 39);
            this.numeric.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.numeric.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numeric.Name = "numeric";
            this.numeric.Size = new System.Drawing.Size(64, 20);
            this.numeric.TabIndex = 14;
            this.numeric.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // slider
            // 
            this.slider.LargeChange = 100;
            this.slider.Location = new System.Drawing.Point(511, 28);
            this.slider.Maximum = 5000;
            this.slider.Minimum = 50;
            this.slider.Name = "slider";
            this.slider.Size = new System.Drawing.Size(327, 45);
            this.slider.SmallChange = 10;
            this.slider.TabIndex = 15;
            this.slider.TickFrequency = 100;
            this.slider.Value = 50;
            this.slider.Scroll += new System.EventHandler(this.slider_Scroll);
            // 
            // PlayerControlBlackJackGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.slider);
            this.Controls.Add(this.numeric);
            this.Controls.Add(this.standButton);
            this.Controls.Add(this.hitButton);
            this.Controls.Add(this.doubleButton);
            this.Name = "PlayerControlBlackJackGUI";
            this.Size = new System.Drawing.Size(980, 95);
            ((System.ComponentModel.ISupportInitialize)(this.numeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Button doubleButton;
        public System.Windows.Forms.Button standButton;
        public System.Windows.Forms.NumericUpDown numeric;
        public System.Windows.Forms.TrackBar slider;
        public System.Windows.Forms.Button hitButton;
    }
}
