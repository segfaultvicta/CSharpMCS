﻿namespace Elena
{
    partial class InputElement
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
			this.comboBox1.BackColor = global::Elena.Properties.Settings.Default.FieldBackColour;
			this.comboBox1.ForeColor = global::Elena.Properties.Settings.Default.FieldTextColour;
			this.comboBox1.FormattingEnabled = true;
			this.comboBox1.Items.AddRange(new object[] {
            "Fire",
            "Ice",
            "Lightning",
            "Water",
            "Shadow",
            "Holy"});
			this.comboBox1.Location = new System.Drawing.Point(39, 12);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(150, 21);
			this.comboBox1.TabIndex = 0;
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Location = new System.Drawing.Point(12, 39);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(94, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "Cancel";
			this.button1.UseVisualStyleBackColor = false;
			// 
			// button2
			// 
			this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button2.Location = new System.Drawing.Point(120, 39);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(94, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "OK";
			this.button2.UseVisualStyleBackColor = false;
			// 
			// InputElement
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::Elena.Properties.Settings.Default.BackColour;
			this.ClientSize = new System.Drawing.Size(226, 72);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.comboBox1);
			this.ForeColor = global::Elena.Properties.Settings.Default.TextColour;
			this.Name = "InputElement";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Choose Element";
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}