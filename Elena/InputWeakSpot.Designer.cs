namespace Elena
{
    partial class InputWeakSpot
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
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.resultText = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.BackColor = global::Elena.Properties.Settings.Default.FieldBackColour;
			this.textBox1.ForeColor = global::Elena.Properties.Settings.Default.FieldTextColour;
			this.textBox1.Location = new System.Drawing.Point(12, 154);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(146, 20);
			this.textBox1.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.BackColor = global::Elena.Properties.Settings.Default.BackColour;
			this.groupBox1.Controls.Add(this.label7);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.ForeColor = global::Elena.Properties.Settings.Default.TextColour;
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(200, 122);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Suggested Triggers / Slot Bonuses";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.BackColor = global::Elena.Properties.Settings.Default.BackColour;
			this.label8.ForeColor = global::Elena.Properties.Settings.Default.TextColour;
			this.label8.Location = new System.Drawing.Point(70, 137);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(40, 13);
			this.label8.TabIndex = 2;
			this.label8.Text = "Trigger";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.BackColor = global::Elena.Properties.Settings.Default.BackColour;
			this.label9.ForeColor = global::Elena.Properties.Settings.Default.TextColour;
			this.label9.Location = new System.Drawing.Point(175, 137);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(37, 13);
			this.label9.TabIndex = 5;
			this.label9.Text = "Bonus";
			// 
			// textBox2
			// 
			this.textBox2.BackColor = global::Elena.Properties.Settings.Default.FieldBackColour;
			this.textBox2.ForeColor = global::Elena.Properties.Settings.Default.FieldTextColour;
			this.textBox2.Location = new System.Drawing.Point(169, 153);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(40, 20);
			this.textBox2.TabIndex = 6;
			// 
			// button1
			// 
			this.button1.BackColor = global::Elena.Properties.Settings.Default.BackColour;
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.ForeColor = global::Elena.Properties.Settings.Default.TextColour;
			this.button1.Location = new System.Drawing.Point(12, 216);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(98, 23);
			this.button1.TabIndex = 7;
			this.button1.Text = "Cancel";
			this.button1.UseVisualStyleBackColor = false;
			// 
			// button2
			// 
			this.button2.BackColor = global::Elena.Properties.Settings.Default.BackColour;
			this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button2.ForeColor = global::Elena.Properties.Settings.Default.TextColour;
			this.button2.Location = new System.Drawing.Point(116, 216);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(98, 23);
			this.button2.TabIndex = 8;
			this.button2.Text = "OK";
			this.button2.UseVisualStyleBackColor = false;
			// 
			// resultText
			// 
			this.resultText.Location = new System.Drawing.Point(12, 190);
			this.resultText.Name = "resultText";
			this.resultText.Size = new System.Drawing.Size(197, 20);
			this.resultText.TabIndex = 9;
			this.resultText.Text = "Result (generally negative status (4))";
			this.resultText.Enter += new System.EventHandler(this.result_Enter);
			this.resultText.Leave += new System.EventHandler(this.result_Leave);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(163, 31);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(13, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "1";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(163, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(13, 13);
			this.label2.TabIndex = 1;
			this.label2.Text = "4";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(18, 78);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(158, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "yo feel free to suggest some shit";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(84, 101);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(105, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "rules are hella vague";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(6, 16);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(155, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "highly specific action, like using";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(24, 55);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(133, 13);
			this.label6.TabIndex = 5;
			this.label6.Text = "inspecific i.e. fire-elemental";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(14, 31);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(143, 13);
			this.label7.TabIndex = 6;
			this.label7.Text = "a Golden Needle on a statue";
			// 
			// InputWeakSpot
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::Elena.Properties.Settings.Default.BackColour;
			this.ClientSize = new System.Drawing.Size(224, 251);
			this.Controls.Add(this.resultText);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.textBox1);
			this.ForeColor = global::Elena.Properties.Settings.Default.TextColour;
			this.Name = "InputWeakSpot";
			this.Text = "Weak Spot";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
		private System.Windows.Forms.TextBox resultText;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
    }
}