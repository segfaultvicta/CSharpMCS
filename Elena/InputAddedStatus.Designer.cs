namespace Elena
{
    partial class InputAddedStatus
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
			this.baseStatusButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.mpCostText = new System.Windows.Forms.Label();
			this.mpButton = new System.Windows.Forms.RadioButton();
			this.delayButton = new System.Windows.Forms.RadioButton();
			this.mpCostLabel = new System.Windows.Forms.Label();
			this.delayText = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.slotCostText = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.gravityCheckBox = new System.Windows.Forms.CheckBox();
			this.potencyText = new System.Windows.Forms.Label();
			this.moreDelayText = new System.Windows.Forms.Label();
			this.moreDelaySlider = new System.Windows.Forms.NumericUpDown();
			this.potencySlider = new System.Windows.Forms.NumericUpDown();
			this.gravityText = new System.Windows.Forms.Label();
			this.cosSlider = new System.Windows.Forms.NumericUpDown();
			this.durationSlider = new System.Windows.Forms.NumericUpDown();
			this.cosText = new System.Windows.Forms.Label();
			this.durationText = new System.Windows.Forms.Label();
			this.summaryText = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.moreDelaySlider)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.potencySlider)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cosSlider)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.durationSlider)).BeginInit();
			this.SuspendLayout();
			// 
			// baseStatusButton
			// 
			this.baseStatusButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.baseStatusButton.Location = new System.Drawing.Point(12, 10);
			this.baseStatusButton.Name = "baseStatusButton";
			this.baseStatusButton.Size = new System.Drawing.Size(191, 23);
			this.baseStatusButton.TabIndex = 0;
			this.baseStatusButton.Text = "Choose Base Status";
			this.baseStatusButton.UseVisualStyleBackColor = false;
			this.baseStatusButton.Click += new System.EventHandler(this.baseStatusButton_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.mpCostText);
			this.groupBox1.Controls.Add(this.mpButton);
			this.groupBox1.Controls.Add(this.delayButton);
			this.groupBox1.Controls.Add(this.mpCostLabel);
			this.groupBox1.Controls.Add(this.delayText);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.slotCostText);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.ForeColor = global::Elena.Properties.Settings.Default.TextColour;
			this.groupBox1.Location = new System.Drawing.Point(209, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(104, 106);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Costs";
			// 
			// mpCostText
			// 
			this.mpCostText.AutoSize = true;
			this.mpCostText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mpCostText.Location = new System.Drawing.Point(75, 81);
			this.mpCostText.Name = "mpCostText";
			this.mpCostText.Size = new System.Drawing.Size(13, 13);
			this.mpCostText.TabIndex = 2;
			this.mpCostText.Text = "0";
			// 
			// mpButton
			// 
			this.mpButton.AutoSize = true;
			this.mpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mpButton.Location = new System.Drawing.Point(6, 81);
			this.mpButton.Name = "mpButton";
			this.mpButton.Size = new System.Drawing.Size(14, 13);
			this.mpButton.TabIndex = 2;
			this.mpButton.TabStop = true;
			this.mpButton.UseVisualStyleBackColor = true;
			// 
			// delayButton
			// 
			this.delayButton.AutoSize = true;
			this.delayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.delayButton.Location = new System.Drawing.Point(6, 58);
			this.delayButton.Name = "delayButton";
			this.delayButton.Size = new System.Drawing.Size(14, 13);
			this.delayButton.TabIndex = 5;
			this.delayButton.TabStop = true;
			this.delayButton.UseVisualStyleBackColor = true;
			// 
			// mpCostLabel
			// 
			this.mpCostLabel.AutoSize = true;
			this.mpCostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.mpCostLabel.Location = new System.Drawing.Point(23, 81);
			this.mpCostLabel.Name = "mpCostLabel";
			this.mpCostLabel.Size = new System.Drawing.Size(55, 13);
			this.mpCostLabel.TabIndex = 4;
			this.mpCostLabel.Text = "+MP/Tier:";
			// 
			// delayText
			// 
			this.delayText.AutoSize = true;
			this.delayText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.delayText.Location = new System.Drawing.Point(75, 58);
			this.delayText.Name = "delayText";
			this.delayText.Size = new System.Drawing.Size(13, 13);
			this.delayText.TabIndex = 3;
			this.delayText.Text = "0";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(35, 58);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(43, 13);
			this.label3.TabIndex = 2;
			this.label3.Text = "+Delay:";
			// 
			// slotCostText
			// 
			this.slotCostText.AutoSize = true;
			this.slotCostText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.slotCostText.Location = new System.Drawing.Point(75, 32);
			this.slotCostText.Name = "slotCostText";
			this.slotCostText.Size = new System.Drawing.Size(13, 13);
			this.slotCostText.TabIndex = 1;
			this.slotCostText.Text = "0";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(26, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Slot Cost:";
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.gravityCheckBox);
			this.groupBox2.Controls.Add(this.potencyText);
			this.groupBox2.Controls.Add(this.moreDelayText);
			this.groupBox2.Controls.Add(this.moreDelaySlider);
			this.groupBox2.Controls.Add(this.potencySlider);
			this.groupBox2.Controls.Add(this.gravityText);
			this.groupBox2.Controls.Add(this.cosSlider);
			this.groupBox2.Controls.Add(this.durationSlider);
			this.groupBox2.Controls.Add(this.cosText);
			this.groupBox2.Controls.Add(this.durationText);
			this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox2.ForeColor = global::Elena.Properties.Settings.Default.TextColour;
			this.groupBox2.Location = new System.Drawing.Point(14, 39);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(189, 99);
			this.groupBox2.TabIndex = 2;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "Modifiers";
			// 
			// gravityCheckBox
			// 
			this.gravityCheckBox.AutoSize = true;
			this.gravityCheckBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gravityCheckBox.Location = new System.Drawing.Point(115, 82);
			this.gravityCheckBox.Name = "gravityCheckBox";
			this.gravityCheckBox.Size = new System.Drawing.Size(15, 14);
			this.gravityCheckBox.TabIndex = 9;
			this.gravityCheckBox.UseVisualStyleBackColor = true;
			this.gravityCheckBox.CheckedChanged += new System.EventHandler(this.gravityCheckBox_CheckedChanged);
			// 
			// potencyText
			// 
			this.potencyText.AutoSize = true;
			this.potencyText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.potencyText.Location = new System.Drawing.Point(90, 33);
			this.potencyText.Name = "potencyText";
			this.potencyText.Size = new System.Drawing.Size(56, 13);
			this.potencyText.TabIndex = 8;
			this.potencyText.Text = "-Dur +CoS";
			// 
			// moreDelayText
			// 
			this.moreDelayText.AutoSize = true;
			this.moreDelayText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.moreDelayText.Location = new System.Drawing.Point(90, 59);
			this.moreDelayText.Name = "moreDelayText";
			this.moreDelayText.Size = new System.Drawing.Size(40, 13);
			this.moreDelayText.TabIndex = 7;
			this.moreDelayText.Text = "+Delay";
			// 
			// moreDelaySlider
			// 
			this.moreDelaySlider.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.moreDelaySlider.Location = new System.Drawing.Point(148, 57);
			this.moreDelaySlider.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
			this.moreDelaySlider.Name = "moreDelaySlider";
			this.moreDelaySlider.Size = new System.Drawing.Size(35, 20);
			this.moreDelaySlider.TabIndex = 6;
			this.moreDelaySlider.ValueChanged += new System.EventHandler(this.moreDelaySlider_ValueChanged);
			// 
			// potencySlider
			// 
			this.potencySlider.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.potencySlider.Location = new System.Drawing.Point(148, 31);
			this.potencySlider.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
			this.potencySlider.Name = "potencySlider";
			this.potencySlider.Size = new System.Drawing.Size(35, 20);
			this.potencySlider.TabIndex = 5;
			this.potencySlider.ValueChanged += new System.EventHandler(this.potencySlider_ValueChanged);
			// 
			// gravityText
			// 
			this.gravityText.AutoSize = true;
			this.gravityText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gravityText.Location = new System.Drawing.Point(46, 83);
			this.gravityText.Name = "gravityText";
			this.gravityText.Size = new System.Drawing.Size(63, 13);
			this.gravityText.TabIndex = 4;
			this.gravityText.Text = "Gravity 50%";
			// 
			// cosSlider
			// 
			this.cosSlider.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cosSlider.Location = new System.Drawing.Point(45, 57);
			this.cosSlider.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
			this.cosSlider.Name = "cosSlider";
			this.cosSlider.Size = new System.Drawing.Size(42, 20);
			this.cosSlider.TabIndex = 3;
			this.cosSlider.ValueChanged += new System.EventHandler(this.cosSlider_ValueChanged);
			// 
			// durationSlider
			// 
			this.durationSlider.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.durationSlider.Location = new System.Drawing.Point(44, 31);
			this.durationSlider.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
			this.durationSlider.Name = "durationSlider";
			this.durationSlider.Size = new System.Drawing.Size(43, 20);
			this.durationSlider.TabIndex = 2;
			this.durationSlider.ValueChanged += new System.EventHandler(this.durationSlider_ValueChanged);
			// 
			// cosText
			// 
			this.cosText.AutoSize = true;
			this.cosText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.cosText.Location = new System.Drawing.Point(6, 59);
			this.cosText.Name = "cosText";
			this.cosText.Size = new System.Drawing.Size(33, 13);
			this.cosText.TabIndex = 1;
			this.cosText.Text = "+CoS";
			// 
			// durationText
			// 
			this.durationText.AutoSize = true;
			this.durationText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.durationText.Location = new System.Drawing.Point(6, 33);
			this.durationText.Name = "durationText";
			this.durationText.Size = new System.Drawing.Size(33, 13);
			this.durationText.TabIndex = 0;
			this.durationText.Text = "+Dur.";
			// 
			// summaryText
			// 
			this.summaryText.AutoSize = true;
			this.summaryText.Font = new System.Drawing.Font("Lucida Console", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.summaryText.Location = new System.Drawing.Point(11, 153);
			this.summaryText.Name = "summaryText";
			this.summaryText.Size = new System.Drawing.Size(61, 12);
			this.summaryText.TabIndex = 3;
			this.summaryText.Text = "SUMMARY:";
			// 
			// okButton
			// 
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.okButton.Location = new System.Drawing.Point(215, 122);
			this.okButton.Name = "okButton";
			this.okButton.Size = new System.Drawing.Size(100, 23);
			this.okButton.TabIndex = 4;
			this.okButton.Text = "OK";
			this.okButton.UseVisualStyleBackColor = false;
			// 
			// InputAddedStatus
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::Elena.Properties.Settings.Default.BackColour;
			this.ClientSize = new System.Drawing.Size(325, 171);
			this.Controls.Add(this.okButton);
			this.Controls.Add(this.summaryText);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.baseStatusButton);
			this.ForeColor = global::Elena.Properties.Settings.Default.TextColour;
			this.Name = "InputAddedStatus";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Build Status Rider...";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.moreDelaySlider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.potencySlider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cosSlider)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.durationSlider)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button baseStatusButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label mpCostText;
        private System.Windows.Forms.RadioButton mpButton;
        private System.Windows.Forms.RadioButton delayButton;
        private System.Windows.Forms.Label mpCostLabel;
        private System.Windows.Forms.Label delayText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label slotCostText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox gravityCheckBox;
        private System.Windows.Forms.Label potencyText;
        private System.Windows.Forms.Label moreDelayText;
        private System.Windows.Forms.NumericUpDown moreDelaySlider;
        private System.Windows.Forms.NumericUpDown potencySlider;
        private System.Windows.Forms.Label gravityText;
        private System.Windows.Forms.NumericUpDown cosSlider;
        private System.Windows.Forms.NumericUpDown durationSlider;
        private System.Windows.Forms.Label cosText;
        private System.Windows.Forms.Label durationText;
        private System.Windows.Forms.Label summaryText;
        private System.Windows.Forms.Button okButton;
    }
}