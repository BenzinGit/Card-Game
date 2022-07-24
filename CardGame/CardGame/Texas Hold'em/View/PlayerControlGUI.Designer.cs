namespace CardGame.Texas_Hold_em.View
{
    partial class PlayerControlGUI
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
            this.checkButton = new System.Windows.Forms.Button();
            this.slider = new System.Windows.Forms.TrackBar();
            this.numeric = new System.Windows.Forms.NumericUpDown();
            this.foldButton = new System.Windows.Forms.Button();
            this.betButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.slider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric)).BeginInit();
            this.SuspendLayout();
            // 
            // checkButton
            // 
            this.checkButton.Enabled = false;
            this.checkButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkButton.Location = new System.Drawing.Point(242, 24);
            this.checkButton.Name = "checkButton";
            this.checkButton.Size = new System.Drawing.Size(100, 39);
            this.checkButton.TabIndex = 2;
            this.checkButton.Text = "Check";
            this.checkButton.UseVisualStyleBackColor = true;
            this.checkButton.Click += new System.EventHandler(this.checkButton_Click);
            // 
            // slider
            // 
            this.slider.LargeChange = 100;
            this.slider.Location = new System.Drawing.Point(524, 18);
            this.slider.Maximum = 5000;
            this.slider.Minimum = 100;
            this.slider.Name = "slider";
            this.slider.Size = new System.Drawing.Size(265, 45);
            this.slider.SmallChange = 10;
            this.slider.TabIndex = 5;
            this.slider.TickFrequency = 100;
            this.slider.Value = 100;
            this.slider.Scroll += new System.EventHandler(this.slider_Scroll);
            // 
            // numeric
            // 
            this.numeric.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numeric.Location = new System.Drawing.Point(454, 32);
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
            this.numeric.TabIndex = 7;
            this.numeric.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // foldButton
            // 
            this.foldButton.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.foldButton.Enabled = false;
            this.foldButton.Location = new System.Drawing.Point(136, 24);
            this.foldButton.Name = "foldButton";
            this.foldButton.Size = new System.Drawing.Size(100, 39);
            this.foldButton.TabIndex = 9;
            this.foldButton.Text = "Fold";
            this.foldButton.UseVisualStyleBackColor = false;
            this.foldButton.Click += new System.EventHandler(this.foldButton_Click);
            // 
            // betButton
            // 
            this.betButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.betButton.Enabled = false;
            this.betButton.ForeColor = System.Drawing.SystemColors.Control;
            this.betButton.Location = new System.Drawing.Point(348, 24);
            this.betButton.Name = "betButton";
            this.betButton.Size = new System.Drawing.Size(100, 39);
            this.betButton.TabIndex = 10;
            this.betButton.Text = "Raise";
            this.betButton.UseVisualStyleBackColor = false;
            this.betButton.Click += new System.EventHandler(this.betButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(795, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "All-in";
            // 
            // PlayerControlGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.betButton);
            this.Controls.Add(this.foldButton);
            this.Controls.Add(this.numeric);
            this.Controls.Add(this.slider);
            this.Controls.Add(this.checkButton);
            this.Name = "PlayerControlGUI";
            this.Size = new System.Drawing.Size(966, 74);
            ((System.ComponentModel.ISupportInitialize)(this.slider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Button checkButton;
        public System.Windows.Forms.Button foldButton;
        public System.Windows.Forms.Button betButton;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TrackBar slider;
        public System.Windows.Forms.NumericUpDown numeric;
    }
}
