namespace Elena
{
    partial class InputElementPresets
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.shadText = new System.Windows.Forms.Label();
            this.holyText = new System.Windows.Forms.Label();
            this.litText = new System.Windows.Forms.Label();
            this.waterText = new System.Windows.Forms.Label();
            this.iceText = new System.Windows.Forms.Label();
            this.fireText = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Primary Element:";
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = Properties.Settings.Default.FieldBackColour;
            this.comboBox1.ForeColor = Properties.Settings.Default.FieldTextColour;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Fire",
            "Ice",
            "Water",
            "Lightning",
            "Holy",
            "Shadow"});
            this.comboBox1.Location = new System.Drawing.Point(103, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(6, 19);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(211, 17);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Set 1: A: Element, W: Opposite (0 slots)";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(6, 42);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(274, 17);
            this.radioButton2.TabIndex = 3;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Set 2: A: Element, W: Opposite, R: Tertiaries (2 slots)";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(6, 65);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(269, 17);
            this.radioButton3.TabIndex = 4;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Set 3: A: Element, W: Opposite, I: Tertiaries (4 slots)";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(6, 88);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(276, 17);
            this.radioButton4.TabIndex = 5;
            this.radioButton4.TabStop = true;
            this.radioButton4.Text = "Set 4: A: Element, W: Opposite, R: All Others (4 slots)";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(309, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(397, 120);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(387, 33);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(9, 13);
            this.label37.TabIndex = 23;
            this.label37.Text = "|";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(387, 22);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(9, 13);
            this.label36.TabIndex = 22;
            this.label36.Text = "|";
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(364, 29);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(58, 13);
            this.label35.TabIndex = 21;
            this.label35.Text = "-----------------";
            // 
            // shadText
            // 
            this.shadText.AutoSize = true;
            this.shadText.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shadText.ForeColor = Properties.Settings.Default.TextColour;
            this.shadText.Location = new System.Drawing.Point(419, 69);
            this.shadText.Name = "shadText";
            this.shadText.Size = new System.Drawing.Size(53, 11);
            this.shadText.TabIndex = 19;
            this.shadText.Text = "Shadow";
            // 
            // holyText
            // 
            this.holyText.AutoSize = true;
            this.holyText.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.holyText.Location = new System.Drawing.Point(317, 69);
            this.holyText.Name = "holyText";
            this.holyText.Size = new System.Drawing.Size(37, 11);
            this.holyText.TabIndex = 18;
            this.holyText.Text = "Holy";
            // 
            // litText
            // 
            this.litText.AutoSize = true;
            this.litText.BackColor = Properties.Settings.Default.BackColour;
            this.litText.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.litText.ForeColor = Properties.Settings.Default.TextColour;
            this.litText.Location = new System.Drawing.Point(355, 49);
            this.litText.Name = "litText";
            this.litText.Size = new System.Drawing.Size(77, 11);
            this.litText.TabIndex = 17;
            this.litText.Text = "Lightning";
            // 
            // waterText
            // 
            this.waterText.AutoSize = true;
            this.waterText.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waterText.ForeColor = Properties.Settings.Default.TextColour;
            this.waterText.Location = new System.Drawing.Point(371, 11);
            this.waterText.Name = "waterText";
            this.waterText.Size = new System.Drawing.Size(45, 11);
            this.waterText.TabIndex = 16;
            this.waterText.Text = "Water";
            // 
            // iceText
            // 
            this.iceText.AutoSize = true;
            this.iceText.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iceText.ForeColor = Properties.Settings.Default.TextColour;
            this.iceText.Location = new System.Drawing.Point(425, 31);
            this.iceText.Name = "iceText";
            this.iceText.Size = new System.Drawing.Size(29, 11);
            this.iceText.TabIndex = 15;
            this.iceText.Text = "Ice";
            // 
            // fireText
            // 
            this.fireText.AutoSize = true;
            this.fireText.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fireText.ForeColor = Properties.Settings.Default.TextColour;
            this.fireText.Location = new System.Drawing.Point(326, 30);
            this.fireText.Name = "fireText";
            this.fireText.Size = new System.Drawing.Size(37, 11);
            this.fireText.TabIndex = 14;
            this.fireText.Text = "Fire";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(358, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "-----------------";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.ForeColor = Properties.Settings.Default.TextColour;
            this.groupBox1.Location = new System.Drawing.Point(15, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(288, 113);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Select Preset";
            // 
            // InputElementPresets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Properties.Settings.Default.BackColour;
            this.ClientSize = new System.Drawing.Size(480, 155);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.shadText);
            this.Controls.Add(this.holyText);
            this.Controls.Add(this.litText);
            this.Controls.Add(this.waterText);
            this.Controls.Add(this.iceText);
            this.Controls.Add(this.fireText);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.ForeColor = Properties.Settings.Default.TextColour;
            this.Name = "InputElementPresets";
            this.Text = "Configure Preset Elemental Properties...";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label shadText;
        private System.Windows.Forms.Label holyText;
        private System.Windows.Forms.Label litText;
        private System.Windows.Forms.Label waterText;
        private System.Windows.Forms.Label iceText;
        private System.Windows.Forms.Label fireText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}