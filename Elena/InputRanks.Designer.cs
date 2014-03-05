namespace Elena
{
    partial class InputRanks
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.ranksBox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.resultText = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ranksBox)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(118, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 24);
            this.button1.TabIndex = 2;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(118, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 26);
            this.button2.TabIndex = 3;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // ranksBox
            // 
            this.ranksBox.BackColor = global::Elena.Properties.Settings.Default.FieldBackColour;
            this.ranksBox.ForeColor = global::Elena.Properties.Settings.Default.FieldTextColour;
            this.ranksBox.Location = new System.Drawing.Point(45, 9);
            this.ranksBox.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.ranksBox.Name = "ranksBox";
            this.ranksBox.Size = new System.Drawing.Size(53, 20);
            this.ranksBox.TabIndex = 4;
            this.ranksBox.ValueChanged += new System.EventHandler(this.slotsBox_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ranks:";
            // 
            // resultText
            // 
            this.resultText.AutoSize = true;
            this.resultText.Location = new System.Drawing.Point(3, 44);
            this.resultText.Name = "resultText";
            this.resultText.Size = new System.Drawing.Size(52, 13);
            this.resultText.TabIndex = 6;
            this.resultText.Text = "Slot Cost:";
            // 
            // InputRanks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::Elena.Properties.Settings.Default.BackColour;
            this.ClientSize = new System.Drawing.Size(225, 76);
            this.Controls.Add(this.resultText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ranksBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.ForeColor = global::Elena.Properties.Settings.Default.TextColour;
            this.Name = "InputRanks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "How Many Ranks?";
            ((System.ComponentModel.ISupportInitialize)(this.ranksBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown ranksBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label resultText;
    }
}