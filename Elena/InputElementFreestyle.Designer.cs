namespace Elena
{
    partial class InputElementFreestyle
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.fireBox = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.slotCost = new System.Windows.Forms.Label();
            this.lightningBox = new System.Windows.Forms.ComboBox();
            this.iceBox = new System.Windows.Forms.ComboBox();
            this.waterBox = new System.Windows.Forms.ComboBox();
            this.holyBox = new System.Windows.Forms.ComboBox();
            this.shadowBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fire:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Lightning:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Ice:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Water:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(34, 117);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Holy:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Shadow:";
            // 
            // fireBox
            // 
            this.fireBox.BackColor = Properties.Settings.Default.FieldBackColour;
            this.fireBox.ForeColor = Properties.Settings.Default.FieldTextColour;
            this.fireBox.FormattingEnabled = true;
            this.fireBox.Items.AddRange(new object[] {
            "Weak",
            "Normal",
            "Resist",
            "Immune",
            "Absorb"});
            this.fireBox.Location = new System.Drawing.Point(69, 6);
            this.fireBox.Name = "fireBox";
            this.fireBox.Size = new System.Drawing.Size(121, 21);
            this.fireBox.TabIndex = 6;
            this.fireBox.SelectedIndexChanged += new System.EventHandler(this.selectedIndexChanged);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(115, 168);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(115, 197);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 14;
            this.label7.Text = "Slot Cost";
            // 
            // slotCost
            // 
            this.slotCost.AutoSize = true;
            this.slotCost.Font = new System.Drawing.Font("Lucida Console", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.slotCost.Location = new System.Drawing.Point(66, 187);
            this.slotCost.Name = "slotCost";
            this.slotCost.Size = new System.Drawing.Size(18, 16);
            this.slotCost.TabIndex = 54;
            this.slotCost.Text = "-";
            // 
            // lightningBox
            // 
            this.lightningBox.BackColor = Properties.Settings.Default.FieldBackColour;
            this.lightningBox.ForeColor = Properties.Settings.Default.FieldTextColour;
            this.lightningBox.FormattingEnabled = true;
            this.lightningBox.Items.AddRange(new object[] {
            "Weak",
            "Normal",
            "Resist",
            "Immune",
            "Absorb"});
            this.lightningBox.Location = new System.Drawing.Point(69, 33);
            this.lightningBox.Name = "lightningBox";
            this.lightningBox.Size = new System.Drawing.Size(121, 21);
            this.lightningBox.TabIndex = 55;
            this.lightningBox.SelectedIndexChanged += new System.EventHandler(this.selectedIndexChanged);
            // 
            // iceBox
            // 
            this.iceBox.BackColor = Properties.Settings.Default.FieldBackColour;
            this.iceBox.ForeColor = Properties.Settings.Default.FieldTextColour;
            this.iceBox.FormattingEnabled = true;
            this.iceBox.Items.AddRange(new object[] {
            "Weak",
            "Normal",
            "Resist",
            "Immune",
            "Absorb"});
            this.iceBox.Location = new System.Drawing.Point(69, 60);
            this.iceBox.Name = "iceBox";
            this.iceBox.Size = new System.Drawing.Size(121, 21);
            this.iceBox.TabIndex = 56;
            this.iceBox.SelectedIndexChanged += new System.EventHandler(this.selectedIndexChanged);
            // 
            // waterBox
            // 
            this.waterBox.BackColor = Properties.Settings.Default.FieldBackColour;
            this.waterBox.ForeColor = Properties.Settings.Default.FieldTextColour;
            this.waterBox.FormattingEnabled = true;
            this.waterBox.Items.AddRange(new object[] {
            "Weak",
            "Normal",
            "Resist",
            "Immune",
            "Absorb"});
            this.waterBox.Location = new System.Drawing.Point(69, 87);
            this.waterBox.Name = "waterBox";
            this.waterBox.Size = new System.Drawing.Size(121, 21);
            this.waterBox.TabIndex = 57;
            this.waterBox.SelectedIndexChanged += new System.EventHandler(this.selectedIndexChanged);
            // 
            // holyBox
            // 
            this.holyBox.BackColor = Properties.Settings.Default.FieldBackColour;
            this.holyBox.ForeColor = Properties.Settings.Default.FieldTextColour;
            this.holyBox.FormattingEnabled = true;
            this.holyBox.Items.AddRange(new object[] {
            "Weak",
            "Normal",
            "Resist",
            "Immune",
            "Absorb"});
            this.holyBox.Location = new System.Drawing.Point(69, 114);
            this.holyBox.Name = "holyBox";
            this.holyBox.Size = new System.Drawing.Size(121, 21);
            this.holyBox.TabIndex = 58;
            this.holyBox.SelectedIndexChanged += new System.EventHandler(this.selectedIndexChanged);
            // 
            // shadowBox
            // 
            this.shadowBox.BackColor = Properties.Settings.Default.FieldBackColour;
            this.shadowBox.ForeColor = Properties.Settings.Default.FieldTextColour;
            this.shadowBox.FormattingEnabled = true;
            this.shadowBox.Items.AddRange(new object[] {
            "Weak",
            "Normal",
            "Resist",
            "Immune",
            "Absorb"});
            this.shadowBox.Location = new System.Drawing.Point(69, 141);
            this.shadowBox.Name = "shadowBox";
            this.shadowBox.Size = new System.Drawing.Size(121, 21);
            this.shadowBox.TabIndex = 59;
            this.shadowBox.SelectedIndexChanged += new System.EventHandler(this.selectedIndexChanged);
            // 
            // InputElementFreestyle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = Properties.Settings.Default.BackColour;
            this.ClientSize = new System.Drawing.Size(202, 228);
            this.Controls.Add(this.shadowBox);
            this.Controls.Add(this.holyBox);
            this.Controls.Add(this.waterBox);
            this.Controls.Add(this.iceBox);
            this.Controls.Add(this.lightningBox);
            this.Controls.Add(this.slotCost);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.fireBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.ForeColor = Properties.Settings.Default.TextColour;
            this.Name = "InputElementFreestyle";
            this.Text = "Freestyle!";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox fireBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label slotCost;
        private System.Windows.Forms.ComboBox lightningBox;
        private System.Windows.Forms.ComboBox iceBox;
        private System.Windows.Forms.ComboBox waterBox;
        private System.Windows.Forms.ComboBox holyBox;
        private System.Windows.Forms.ComboBox shadowBox;
    }
}