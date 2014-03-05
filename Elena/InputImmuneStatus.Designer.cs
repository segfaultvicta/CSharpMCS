namespace Elena
{
    partial class InputImmuneStatus
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = Properties.Settings.Default.FieldBackColour;
            this.comboBox1.ForeColor = Properties.Settings.Default.FieldTextColour;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Sleep, Stop, Toad, Near-Fatal, Death, Stone, Eject & Condemn",
            "Charm, Berserk, Provoke & Confuse",
            "Poison & Gravity",
            "Berserk",
            "Blind",
            "Charm",
            "Condemn",
            "Confuse",
            "Curse",
            "Debrave",
            "Defaith",
            "Deprotect",
            "Deshell",
            "Evasion Down",
            "Immobilize",
            "Imperil",
            "Lock",
            "Pain",
            "Poison",
            "Provoke",
            "Sap",
            "Seal",
            "Silence",
            "Sleep",
            "Slow",
            "Stone",
            "Stop",
            "Toad",
            "Zombie",
            "Death",
            "Delay",
            "Dispel",
            "Eject",
            "Gravity",
            "Libra",
            "Near-Fatal",
            "Push"});
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(276, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Location = new System.Drawing.Point(12, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(127, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.Location = new System.Drawing.Point(145, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(143, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // InputImmuneStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Properties.Settings.Default.BackColour;
            this.ClientSize = new System.Drawing.Size(300, 74);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.ForeColor = Properties.Settings.Default.TextColour;
            this.Name = "InputImmuneStatus";
            this.Text = "Pick Immunity...";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}