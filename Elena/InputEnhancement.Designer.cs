namespace Elena
{
    partial class InputEnhancement
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
			this.addStatusButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.statusList = new System.Windows.Forms.ListBox();
			this.button2 = new System.Windows.Forms.Button();
			this.slotCostText = new System.Windows.Forms.Label();
			this.techButton = new System.Windows.Forms.RadioButton();
			this.magspellButton = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.durationLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// addStatusButton
			// 
			this.addStatusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.addStatusButton.Location = new System.Drawing.Point(12, 10);
			this.addStatusButton.Name = "addStatusButton";
			this.addStatusButton.Size = new System.Drawing.Size(100, 23);
			this.addStatusButton.TabIndex = 0;
			this.addStatusButton.Text = "Add A Status";
			this.addStatusButton.UseVisualStyleBackColor = false;
			this.addStatusButton.Click += new System.EventHandler(this.baseStatusButton_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(118, 56);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Slot Cost:";
			// 
			// okButton
			// 
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.okButton.Location = new System.Drawing.Point(118, 130);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(100, 23);
			this.okButton.TabIndex = 4;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = false;
			// 
			// button1
			// 
			this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.button1.Location = new System.Drawing.Point(118, 101);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(100, 23);
			this.button1.TabIndex = 10;
			this.button1.Text = "Cancel";
			this.button1.UseVisualStyleBackColor = false;
			// 
			// statusList
			// 
			this.statusList.FormattingEnabled = true;
			this.statusList.Location = new System.Drawing.Point(12, 39);
			this.statusList.Name = "statusList";
			this.statusList.Size = new System.Drawing.Size(100, 56);
			this.statusList.TabIndex = 11;
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(12, 101);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(100, 23);
			this.button2.TabIndex = 12;
			this.button2.Text = "Delete A Status";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// slotCostText
			// 
			this.slotCostText.AutoSize = true;
			this.slotCostText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.slotCostText.Location = new System.Drawing.Point(176, 56);
			this.slotCostText.Name = "slotCostText";
			this.slotCostText.Size = new System.Drawing.Size(13, 13);
			this.slotCostText.TabIndex = 1;
			this.slotCostText.Text = "0";
			// 
			// techButton
			// 
			this.techButton.AutoSize = true;
			this.techButton.Checked = true;
			this.techButton.Location = new System.Drawing.Point(126, 10);
			this.techButton.Name = "techButton";
			this.techButton.Size = new System.Drawing.Size(76, 17);
			this.techButton.TabIndex = 13;
			this.techButton.TabStop = true;
			this.techButton.Text = "Technique";
			this.techButton.UseVisualStyleBackColor = true;
			// 
			// magspellButton
			// 
			this.magspellButton.AutoSize = true;
			this.magspellButton.Location = new System.Drawing.Point(126, 33);
			this.magspellButton.Name = "magspellButton";
			this.magspellButton.Size = new System.Drawing.Size(83, 17);
			this.magspellButton.TabIndex = 14;
			this.magspellButton.TabStop = true;
			this.magspellButton.Text = "Magic, Spell";
			this.magspellButton.UseVisualStyleBackColor = true;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(118, 82);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 13);
			this.label2.TabIndex = 15;
			this.label2.Text = "Duration:";
			// 
			// durationLabel
			// 
			this.durationLabel.AutoSize = true;
			this.durationLabel.Location = new System.Drawing.Point(176, 82);
			this.durationLabel.Name = "durationLabel";
			this.durationLabel.Size = new System.Drawing.Size(13, 13);
			this.durationLabel.TabIndex = 16;
			this.durationLabel.Text = "5";
			// 
			// InputEnhancement
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::Elena.Properties.Settings.Default.BackColour;
			this.ClientSize = new System.Drawing.Size(223, 157);
			this.Controls.Add(this.durationLabel);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.magspellButton);
			this.Controls.Add(this.techButton);
			this.Controls.Add(this.slotCostText);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.statusList);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.addStatusButton);
			this.ForeColor = global::Elena.Properties.Settings.Default.TextColour;
			this.Name = "InputEnhancement";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Build Enhancement....";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.Windows.Forms.Button addStatusButton;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox statusList;
        private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label slotCostText;
		private System.Windows.Forms.RadioButton techButton;
		private System.Windows.Forms.RadioButton magspellButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label durationLabel;
    }
}