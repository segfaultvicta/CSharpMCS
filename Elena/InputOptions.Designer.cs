namespace Elena
{
    partial class InputOptions
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.errorColorPanel = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.absorbColorPanel = new System.Windows.Forms.Panel();
            this.immuneColorPanel = new System.Windows.Forms.Panel();
            this.resistColorPanel = new System.Windows.Forms.Panel();
            this.normalColorPanel = new System.Windows.Forms.Panel();
            this.weaknessColorPanel = new System.Windows.Forms.Panel();
            this.fieldTextColorPanel = new System.Windows.Forms.Panel();
            this.fieldColorPanel = new System.Windows.Forms.Panel();
            this.backColorPanel = new System.Windows.Forms.Panel();
            this.textColorPanel = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.defaultsButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.errorColorPanel);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.absorbColorPanel);
            this.groupBox1.Controls.Add(this.immuneColorPanel);
            this.groupBox1.Controls.Add(this.resistColorPanel);
            this.groupBox1.Controls.Add(this.normalColorPanel);
            this.groupBox1.Controls.Add(this.weaknessColorPanel);
            this.groupBox1.Controls.Add(this.fieldTextColorPanel);
            this.groupBox1.Controls.Add(this.fieldColorPanel);
            this.groupBox1.Controls.Add(this.backColorPanel);
            this.groupBox1.Controls.Add(this.textColorPanel);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = global::Elena.Properties.Settings.Default.TextColour;
            this.groupBox1.Location = new System.Drawing.Point(4, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 239);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Colour Scheme";
            // 
            // errorColorPanel
            // 
            this.errorColorPanel.BackColor = global::Elena.Properties.Settings.Default.TextColour;
            this.errorColorPanel.Location = new System.Drawing.Point(118, 210);
            this.errorColorPanel.Name = "errorColorPanel";
            this.errorColorPanel.Padding = new System.Windows.Forms.Padding(8);
            this.errorColorPanel.Size = new System.Drawing.Size(69, 15);
            this.errorColorPanel.TabIndex = 19;
            this.errorColorPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorPanel_MouseClick);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(8, 214);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Error Text";
            // 
            // absorbColorPanel
            // 
            this.absorbColorPanel.BackColor = global::Elena.Properties.Settings.Default.TextColour;
            this.absorbColorPanel.Location = new System.Drawing.Point(118, 186);
            this.absorbColorPanel.Name = "absorbColorPanel";
            this.absorbColorPanel.Padding = new System.Windows.Forms.Padding(8);
            this.absorbColorPanel.Size = new System.Drawing.Size(69, 15);
            this.absorbColorPanel.TabIndex = 17;
            this.absorbColorPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorPanel_MouseClick);
            // 
            // immuneColorPanel
            // 
            this.immuneColorPanel.BackColor = global::Elena.Properties.Settings.Default.TextColour;
            this.immuneColorPanel.Location = new System.Drawing.Point(118, 166);
            this.immuneColorPanel.Name = "immuneColorPanel";
            this.immuneColorPanel.Padding = new System.Windows.Forms.Padding(8);
            this.immuneColorPanel.Size = new System.Drawing.Size(69, 15);
            this.immuneColorPanel.TabIndex = 16;
            this.immuneColorPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorPanel_MouseClick);
            // 
            // resistColorPanel
            // 
            this.resistColorPanel.BackColor = global::Elena.Properties.Settings.Default.TextColour;
            this.resistColorPanel.Location = new System.Drawing.Point(118, 145);
            this.resistColorPanel.Name = "resistColorPanel";
            this.resistColorPanel.Padding = new System.Windows.Forms.Padding(8);
            this.resistColorPanel.Size = new System.Drawing.Size(69, 15);
            this.resistColorPanel.TabIndex = 15;
            this.resistColorPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorPanel_MouseClick);
            // 
            // normalColorPanel
            // 
            this.normalColorPanel.BackColor = global::Elena.Properties.Settings.Default.TextColour;
            this.normalColorPanel.Location = new System.Drawing.Point(118, 124);
            this.normalColorPanel.Name = "normalColorPanel";
            this.normalColorPanel.Padding = new System.Windows.Forms.Padding(8);
            this.normalColorPanel.Size = new System.Drawing.Size(69, 15);
            this.normalColorPanel.TabIndex = 14;
            this.normalColorPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorPanel_MouseClick);
            // 
            // weaknessColorPanel
            // 
            this.weaknessColorPanel.BackColor = global::Elena.Properties.Settings.Default.TextColour;
            this.weaknessColorPanel.Location = new System.Drawing.Point(118, 103);
            this.weaknessColorPanel.Name = "weaknessColorPanel";
            this.weaknessColorPanel.Padding = new System.Windows.Forms.Padding(8);
            this.weaknessColorPanel.Size = new System.Drawing.Size(69, 15);
            this.weaknessColorPanel.TabIndex = 13;
            this.weaknessColorPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorPanel_MouseClick);
            // 
            // fieldTextColorPanel
            // 
            this.fieldTextColorPanel.BackColor = global::Elena.Properties.Settings.Default.TextColour;
            this.fieldTextColorPanel.Location = new System.Drawing.Point(118, 82);
            this.fieldTextColorPanel.Name = "fieldTextColorPanel";
            this.fieldTextColorPanel.Padding = new System.Windows.Forms.Padding(8);
            this.fieldTextColorPanel.Size = new System.Drawing.Size(69, 15);
            this.fieldTextColorPanel.TabIndex = 12;
            this.fieldTextColorPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorPanel_MouseClick);
            // 
            // fieldColorPanel
            // 
            this.fieldColorPanel.BackColor = global::Elena.Properties.Settings.Default.TextColour;
            this.fieldColorPanel.Location = new System.Drawing.Point(118, 60);
            this.fieldColorPanel.Name = "fieldColorPanel";
            this.fieldColorPanel.Padding = new System.Windows.Forms.Padding(8);
            this.fieldColorPanel.Size = new System.Drawing.Size(69, 15);
            this.fieldColorPanel.TabIndex = 11;
            this.fieldColorPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorPanel_MouseClick);
            // 
            // backColorPanel
            // 
            this.backColorPanel.BackColor = global::Elena.Properties.Settings.Default.BackColour;
            this.backColorPanel.Location = new System.Drawing.Point(118, 38);
            this.backColorPanel.Name = "backColorPanel";
            this.backColorPanel.Padding = new System.Windows.Forms.Padding(8);
            this.backColorPanel.Size = new System.Drawing.Size(69, 15);
            this.backColorPanel.TabIndex = 10;
            this.backColorPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            this.backColorPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorPanel_MouseClick);
            // 
            // textColorPanel
            // 
            this.textColorPanel.BackColor = global::Elena.Properties.Settings.Default.TextColour;
            this.textColorPanel.Location = new System.Drawing.Point(118, 16);
            this.textColorPanel.Name = "textColorPanel";
            this.textColorPanel.Padding = new System.Windows.Forms.Padding(8);
            this.textColorPanel.Size = new System.Drawing.Size(69, 15);
            this.textColorPanel.TabIndex = 9;
            this.textColorPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.colorPanel_MouseClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 192);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Absorb";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Immune";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(36, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Resist";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 126);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Normal";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Weakness";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(8, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Field Text Colour";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Field Colour";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Background Colour";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Text Colour";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(122, 257);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 22);
            this.button1.TabIndex = 1;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // defaultsButton
            // 
            this.defaultsButton.Location = new System.Drawing.Point(4, 256);
            this.defaultsButton.Name = "defaultsButton";
            this.defaultsButton.Size = new System.Drawing.Size(112, 23);
            this.defaultsButton.TabIndex = 2;
            this.defaultsButton.Text = "Restore Defaults";
            this.defaultsButton.UseVisualStyleBackColor = false;
            this.defaultsButton.Click += new System.EventHandler(this.defaultsButton_Click);
            // 
            // InputOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = global::Elena.Properties.Settings.Default.BackColour;
            this.ClientSize = new System.Drawing.Size(209, 291);
            this.Controls.Add(this.defaultsButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = global::Elena.Properties.Settings.Default.TextColour;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "InputOptions";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MCS Options";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel textColorPanel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Panel backColorPanel;
        private System.Windows.Forms.Panel absorbColorPanel;
        private System.Windows.Forms.Panel immuneColorPanel;
        private System.Windows.Forms.Panel resistColorPanel;
        private System.Windows.Forms.Panel normalColorPanel;
        private System.Windows.Forms.Panel weaknessColorPanel;
        private System.Windows.Forms.Panel fieldTextColorPanel;
        private System.Windows.Forms.Panel fieldColorPanel;
        private System.Windows.Forms.Panel errorColorPanel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button defaultsButton;

    }
}